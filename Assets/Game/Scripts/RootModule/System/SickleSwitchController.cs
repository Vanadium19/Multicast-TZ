using EntityModule;
using InstrumentsModule;
using PlayerModule;
using UnityEngine;
using Zenject;

namespace RootModule
{
    public class SickleSwitchController : MonoBehaviour
    {
        private IHarvestController _harvestController;

        [Inject]
        public void Construct(IHarvestController harvestController)
        {
            _harvestController = harvestController;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (!entity.TryGet(out Player player))
                return;

            _harvestController.Enable(true);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (!entity.TryGet(out Player player))
                return;

            _harvestController.Enable(false);
        }
    }
}