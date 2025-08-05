using UnityEngine;

namespace InstrumentsModule
{
    [CreateAssetMenu(fileName = "SickleConfig", menuName = "Game/Configs/SickleConfig")]
    public class SickleConfig : UpgradableConfig
    {
        [SerializeField] private float _delay = 2f;

        [SerializeField] private float _startRadius = 2f;
        [SerializeField] private float _maxRadius = 5f;

        [SerializeField] private LayerMask _layerMask;

        public float Delay => _delay;

        public float StartRadius => _startRadius;
        public float MaxRadius => _maxRadius;

        public LayerMask LayerMask => _layerMask;
    }
}