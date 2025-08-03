using R3;

namespace InstrumentsModule
{
    public interface IUpgradeSystem
    {
        public ReadOnlyReactiveProperty<bool> IsActive { get; }
        public ReadOnlyReactiveProperty<float> Progress { get; }
        public ReadOnlyReactiveProperty<int> Price { get; }
        public bool CanBuy { get; }

        public void BuyUpgrade();
    }
}