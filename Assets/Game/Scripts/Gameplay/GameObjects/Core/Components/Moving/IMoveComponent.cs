using UnityEngine;

namespace Gameplay.Core.Components
{
    public interface IMoveComponent
    {
        public void Move(Vector3 direction);
    }
}