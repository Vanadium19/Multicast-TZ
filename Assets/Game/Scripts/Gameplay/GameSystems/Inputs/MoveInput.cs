using UnityEngine;

namespace Gameplay.GameSystems.Inputs
{
    public class MoveInput : IMoveInput
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";

        public Vector3 Direction => _directionX + _directionZ;

        private Vector3 _directionX => Input.GetAxisRaw(Horizontal) * Vector3.right;
        private Vector3 _directionZ => Input.GetAxisRaw(Vertical) * Vector3.forward;
    }
}