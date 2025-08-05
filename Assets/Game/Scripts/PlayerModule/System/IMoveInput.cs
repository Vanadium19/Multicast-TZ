using UnityEngine;

namespace PlayerModule
{
    public interface IMoveInput
    {
        public Vector3 Direction { get; }
    }
}