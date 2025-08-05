using System.Linq;
using InventoryModule;
using UnityEngine;
using Zenject;

namespace InstrumentsModule
{
    internal class HarvestController : ITickable, IHarvestController
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

            _lastCollectTime = Time.time;

            var grass = _sickle.Chop();

            if (!grass.Any())
                return;

            _bag.Add(grass);
        }
    }
}