using System;
using System.Threading;
using ComponentsModule;
using Cysharp.Threading.Tasks;
using FSMModule;
using UnityEngine;

namespace BotModule
{
    internal class MovingState : IState
    {
        private readonly ITargetMoveComponent _moveComponent;
        private readonly IRotationComponent _rotationComponent;

        private readonly Blackboard _blackboard;
        private readonly Transform _transform;
        private readonly Path _path;

        private PathPoint _currentPoint;
        private PathPoint _lastPoint;

        private CancellationTokenSource _tokenSource;

        public MovingState(ITargetMoveComponent moveComponent,
            IRotationComponent rotationComponent,
            Blackboard blackboard,
            Transform transform,
            Path path)
        {
            _moveComponent = moveComponent;
            _rotationComponent = rotationComponent;

            _blackboard = blackboard;
            _transform = transform;
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
            position.y = _transform.position.y;

            var direction = (position - _transform.position).normalized;
            _rotationComponent.Rotate(direction);

            await _moveComponent.MoveToTarget(position, cancellationToken);

            await UniTask.Delay(TimeSpan.FromSeconds(_currentPoint.Delay), cancellationToken: cancellationToken);

            _lastPoint = _currentPoint;
            _currentPoint = _path.GetNextPoint(_currentPoint);

            MoveToTarget().Forget();
        }
    }
}