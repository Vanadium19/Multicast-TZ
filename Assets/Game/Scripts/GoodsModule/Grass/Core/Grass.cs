using R3;
using UnityEngine;

namespace GoodsModule
{
    public class Grass : IGrass
    {
        private readonly Collider _collider;
        private readonly GoodConfig _goodConfig;

        private readonly ReactiveProperty<bool> _isCollected = new();

        public Grass(Collider collider, GoodConfig goodConfig)
        {
            _collider = collider;
            _goodConfig = goodConfig;
        }

        public int Price => _goodConfig.Price;
        public ReadOnlyReactiveProperty<bool> IsCollected => _isCollected;

        public void Collect()
        {
            _collider.enabled = false;
            _isCollected.Value = true;
        }
    }
}