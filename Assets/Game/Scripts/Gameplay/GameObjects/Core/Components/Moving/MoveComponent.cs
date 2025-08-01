using UnityEngine;

namespace Gameplay.Core.Components
{
    public class MoveComponent : IMoveComponent
    {
        private readonly Rigidbody _rigidbody;
        private readonly float _speed;

        public MoveComponent(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void Move(Vector3 direction)
        {
            _rigidbody.velocity = direction * _speed;
        }
    }
}