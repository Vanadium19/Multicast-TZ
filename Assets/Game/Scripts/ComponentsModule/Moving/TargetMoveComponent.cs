using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using R3;
using UnityEngine;

namespace ComponentsModule
{
    public class TargetMoveComponent : ITargetMoveComponent
    {
        private const int MovingStopDelay = 3;

        private readonly Transform _transform;
        private readonly float _speed;

        private readonly ReactiveProperty<bool> _isMoving = new();

        private Tween _moveTween;
        private bool _cancelationReigistred;

        public TargetMoveComponent(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public ReadOnlyReactiveProperty<bool> IsMoving => _isMoving;

        public Tween MoveToTarget(Vector3 position, CancellationToken cancellationToken = default)
        {
            _isMoving.Value = true;

            _moveTween = _transform.DOMove(position, _speed)
                .SetEase(Ease.Linear)
                .SetSpeedBased(true)
                .OnComplete(() => SetMovingBoolAsync(cancellationToken).Forget());

            if (cancellationToken.CanBeCanceled)
                RegisterCancellation(cancellationToken);

            return _moveTween;
        }

        private void RegisterCancellation(CancellationToken cancellationToken)
        {
            if (_cancelationReigistred)
                return;

            _cancelationReigistred = true;
            cancellationToken.Register(KillTween);
        }

        private void KillTween()
        {
            _cancelationReigistred = false;
            _isMoving.Value = false;

            _moveTween?.Kill();
            _moveTween = null;
        }

        private async UniTaskVoid SetMovingBoolAsync(CancellationToken cancellationToken)
        {
            await UniTask.DelayFrame(MovingStopDelay, cancellationToken: cancellationToken);

            if (_moveTween.IsActive() && _moveTween.IsPlaying())
                return;

            _isMoving.Value = false;
        }
    }
}