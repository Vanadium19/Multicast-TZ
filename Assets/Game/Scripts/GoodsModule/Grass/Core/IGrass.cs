using InventoryModule;
using R3;

namespace GoodsModule
{
    public interface IGrass : IGood
    {
        public ReadOnlyReactiveProperty<bool> IsCollected { get; }

        public void Collect();
    }
}