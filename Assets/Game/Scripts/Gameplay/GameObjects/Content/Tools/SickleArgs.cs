using System;
using UnityEngine;

namespace Gameplay.Content.Tools
{
    [Serializable]
    public class SickleArgs
    {
        [SerializeField] private float _radius = 5f;
        [SerializeField] private Transform _point;
        [SerializeField] private LayerMask _layerMask;

        public float Radius => _radius;
        public Transform Transform => _point;
        public Vector3 Point => _point.position;
        public LayerMask LayerMask => _layerMask;
    }
}