using Common;
using UnityEngine;

namespace PlayerModule
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void SetMoving(bool value)
        {
            _animator.SetBool(AnimationHashes.IsMoving, value);
        }
    }
}