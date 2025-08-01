using R3;

namespace System.Collections.Generic
{
    public interface IUpgradeable
    {
        public bool CanUpgrade { get; }
        public int Price { get; }
        public ReadOnlyReactiveProperty<float> Progress { get; }

        public void Upgrade();
    }
}