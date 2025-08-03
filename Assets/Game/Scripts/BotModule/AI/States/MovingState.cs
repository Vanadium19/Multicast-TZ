using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using FSMModule;
using UnityEngine;

namespace BotModule
{
    public class MovingState : IState
    {
        private readonly Blackboard _blackboard;
        private readonly Transform _transform;
        private readonly float _speed;

        private readonly Path _path;

        private PathPoint _currentPoint;

        private CancellationTokenSource _tokenSource;

        public MovingState(Blackboard blackboard,
            Transform transform,
            float speed,
            Path path)
        {
            _blackboard = blackboard;
            _transform = transform;
            _speed = speed;
            _path = path;
        }

        public void OnEnter()
        {
            _tokenSource = new CancellationTokenSource();

            if (!_currentPoint)
                _currentPoint = _path.GetFirstPoint();

            MoveToTarget().Forget();
        }

        public void OnUpdate(float deltaTime)
        {
        }

        public void OnExit()
        {
            var isFinished = _blackboard.GetBool((int)BlackboardTag.IsFinished);

            _tokenSource.Cancel();
            _tokenSource.Dispose();

            if (isFinished)
                _currentPoint = null;
        }

        private async UniTaskVoid MoveToTarget()
        {
            var cancelToken = _tokenSource.Token;

            var position = _currentPoint.Position;
            position.y = _transform.position.y;

            await UniTask.WaitWhile(() => _currentPoint.IsBusy, cancellationToken: cancelToken);

            _currentPoint.SetBusy(true);

            var moveTween = _transform.DOMove(position, _speed).SetEase(Ease.Linear).SetSpeedBased(true);
            cancelToken.Register(() =>
            {
                moveTween.Kill();
                _currentPoint.SetBusy(false);
            });

            await moveTween;

            await UniTask.Delay(TimeSpan.FromSeconds(_currentPoint.Delay), cancellationToken: cancelToken);

            _currentPoint.SetBusy(false);
            _currentPoint = _path.GetNextPoint(_currentPoint);

            MoveToTarget().Forget();
        }
    }
}