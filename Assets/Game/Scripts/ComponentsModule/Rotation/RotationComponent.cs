using UnityEngine;

namespace ComponentsModule
{
    public class RotationComponent : IRotationComponent
    {
        private readonly Transform _transform;

        public RotationComponent(Transform transform)
        {
            _transform = transform;
        }

        public void Rotate(Vector3 direction)
        {
            if (direction == Vector3.zero)
                return;

            var rotation = Quaternion.LookRotation(direction);

            _transform.rotation = rotation;
        }
    }
}