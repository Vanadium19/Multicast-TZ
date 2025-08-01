using R3;

namespace WalletModule
{
    internal class Wallet : IWallet
    {
        private readonly ReactiveProperty<int> _money = new();

        public ReadOnlyReactiveProperty<int> Money => _money;

        public void AddMoney(int amount)
        {
            if (amount <= 0)
                return;

            _money.Value += amount;
        }

        public void RemoveMoney(int amount)
        {
            if (amount <= 0)
                return;

            if (_money.Value < amount)
                return;

            _money.Value -= amount;
        }
    }
}