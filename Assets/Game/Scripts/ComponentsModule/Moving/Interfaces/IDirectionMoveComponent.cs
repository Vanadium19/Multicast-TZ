using UnityEngine;

namespace ComponentsModule
{
    public interface IDirectionMoveComponent : IMoveComponent
    {
        public void Move(Vector3 direction);
    }
}