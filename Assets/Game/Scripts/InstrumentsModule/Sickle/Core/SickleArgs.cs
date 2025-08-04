using System;
using UnityEngine;

namespace InstrumentsModule
{
    [Serializable]
    public class SickleArgs
    {
        [SerializeField] private float _delay = 2f;

        [SerializeField] private float _startRadius = 2f;
        [SerializeField] private float _maxRadius = 5f;

        [SerializeField] private Transform _transform;
        [SerializeField] private LayerMask _layerMask;

        public float Delay => _delay;

        public float StartRadius => _startRadius;
        public float MaxRadius => _maxRadius;

        public Transform Transform => _transform;
        public Vector3 Point => _transform.position;
        public LayerMask LayerMask => _layerMask;
    }
}