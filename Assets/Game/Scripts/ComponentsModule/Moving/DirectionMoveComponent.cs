using R3;
using UnityEngine;

namespace ComponentsModule
{
    public class DirectionMoveComponent : IDirectionMoveComponent
    {
        private readonly Rigidbody _rigidbody;
        private readonly float _speed;

        private readonly ReactiveProperty<bool> _isMoving = new();

        public DirectionMoveComponent(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public ReadOnlyReactiveProperty<bool> IsMoving => _isMoving;

        public void Move(Vector3 direction)
        {
            _isMoving.Value = direction != Vector3.zero;
            _rigidbody.velocity = direction * _speed;
        }
    }
}