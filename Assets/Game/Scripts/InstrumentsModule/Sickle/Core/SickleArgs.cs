using System;
using UnityEngine;

namespace InstrumentsModule
{
    [Serializable]
    public class SickleArgs
    {
        [SerializeField] private SickleConfig _config;
        [SerializeField] private Transform _transform;
        
        internal SickleArgs(SickleConfig config, Transform transform)
        {
            _config = config;
            _transform = transform;
        }

        public float Delay => _config.Delay;

        public float StartRadius => _config.StartRadius;
        public float MaxRadius => _config.MaxRadius;

        public Transform Transform => _transform;
        public Vector3 Point => _transform.position;
        public LayerMask LayerMask => _config.LayerMask;

        public int Price => _config.Price;
    }
}