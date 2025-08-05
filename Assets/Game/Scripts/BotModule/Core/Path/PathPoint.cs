using UnityEngine;

namespace BotModule
{
    internal class PathPoint : MonoBehaviour
    {
        [SerializeField] private float _delay;

        private bool _isBusy;

        public Vector3 Position => transform.position;
        public bool IsBusy => _isBusy;
        public float Delay => _delay;

        public void SetBusy(bool value)
        {
            _isBusy = value;
        }
    }
}