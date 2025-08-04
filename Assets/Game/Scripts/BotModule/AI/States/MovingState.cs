using System;
using System.Threading;
using ComponentsModule;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using FSMModule;
using UnityEngine;

namespace BotModule
{
    public class MovingState : IState
    {
        private readonly ITargetMoveComponent _moveComponent;
        private readonly Blackboard _blackboard;
        private readonly Path _path;

        private PathPoint _currentPoint;
        private PathPoint _lastPoint;

        private CancellationTokenSource _tokenSource;

        public MovingState(ITargetMoveComponent moveComponent,
            Blackboard blackboard,
            Path path)
        {
            _moveComponent = moveComponent;
            _blackboard = blackboard;
            _path = path;
        }

        public void OnEnter()
        {
            _tokenSource = new CancellationTokenSource();

            var isContinue = _currentPoint != null;

            if (!isContinue)
                _currentPoint = _path.GetFirstPoint();

            MoveToTarget(isContinue).Forget();
        }

        public void OnUpdate(float deltaTime)
        {
        }

        public void OnExit()
        {
            _blackboard.TryGetBool((int)BlackboardTag.IsFinished, out bool isFinished);

            _tokenSource.Cancel();
            _tokenSource.Dispose();

            _lastPoint = null;

            if (!isFinished)
                return;

            _currentPoint.SetBusy(false);
            _currentPoint = null;
        }

        private async UniTaskVoid MoveToTarget(bool isContinue = false)
        {
            var cancellationToken = _tokenSource.Token;

            if (!isContinue)
                await UniTask.WaitWhile(() => _currentPoint.IsBusy, cancellationToken: cancellationToken);

            _lastPoint?.SetBusy(false);
            _currentPoint.SetBusy(true);

            var position = _currentPoint.Position;
            await _moveComponent.MoveToTarget(position, cancellationToken);

            await UniTask.Delay(TimeSpan.FromSeconds(_currentPoint.Delay), cancellationToken: cancellationToken);

            _lastPoint = _currentPoint;
            _currentPoint = _path.GetNextPoint(_currentPoint);

            MoveToTarget().Forget();
        }
    }
}