using System.Linq;
using Gameplay.Content.Inventory;
using Gameplay.Content.Tools;
using UnityEngine;
using Zenject;

namespace Gameplay.GameSystems.Controllers
{
    public class HarvestController : ITickable, IHarvestController
    {
        private readonly ISickle _sickle;
        private readonly IBag _bag;

        private readonly float _delay;

        private float _lastCollectTime;
        private bool _isActive;

        public HarvestController(ISickle sickle, IBag bag, float delay)
        {
            _sickle = sickle;
            _bag = bag;
            _delay = delay;

            //Temporary solution to enable harvesting
            Enable(true);
        }

        public void Tick()
        {
            if (!_isActive)
                return;

            Collect();
        }

        public void Enable(bool value)
        {
            _isActive = value;
        }

        private void Collect()
        {
            if (Time.time - _lastCollectTime < _delay)
                return;

            var grass = _sickle.CollectGrass();

            if (!grass.Any())
                return;

            _bag.Add(grass);

            _lastCollectTime = Time.time;
        }
    }
}