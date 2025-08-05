using UnityEngine;

namespace InstrumentsModule
{
    public class SickleView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _upgradeParticles;
        [SerializeField] private ParticleSystem _choppingParticles;

        public void SetChoppingAnimation()
        {
            _choppingParticles.Play();
        }

        public void SetUpgradeAnimation()
        {
            _upgradeParticles.Clear();
            _upgradeParticles.Play();
        }
    }
}