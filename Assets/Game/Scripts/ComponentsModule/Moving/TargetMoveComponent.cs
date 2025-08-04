using System.Threading;
using DG.Tweening;
using R3;
using UnityEngine;

namespace ComponentsModule
{
    public class TargetMoveComponent : ITargetMoveComponent
    {
        private readonly Transform _transform;
        private readonly float _speed;

        private readonly ReactiveProperty<bool> _isMoving = new();

        private Tween _moveTween;

        public TargetMoveComponent(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public ReadOnlyReactiveProperty<bool> IsMoving => _isMoving;

        public Tween MoveToTarget(Vector3 position, CancellationToken cancellationToken = default)
        {
            _isMoving.Value = true;

            _moveTween?.Kill();
            _moveTween = _transform.DOMove(position, _speed)
                .SetEase(Ease.Linear)
                .SetSpeedBased(true)
                .OnComplete(() => _isMoving.Value = false);

            if (cancellationToken.CanBeCanceled)
                cancellationToken.Register(KillTween);

            return _moveTween;
        }

        private void KillTween()
        {
            _moveTween?.Kill();
            _moveTween = null;

            _isMoving.Value = false;
        }
    }
}