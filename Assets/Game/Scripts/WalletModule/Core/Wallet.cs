using R3;

namespace WalletModule
{
    internal class Wallet : IWallet
    {
        private readonly ReactiveProperty<int> _money = new();
        private readonly Subject<int> _moneyAdded = new();

        public ReadOnlyReactiveProperty<int> Money => _money;
        public Observable<int> MoneyAdded => _moneyAdded;

        public void AddMoney(int amount)
        {
            if (amount <= 0)
                return;

            _money.Value += amount;
            _moneyAdded.OnNext(amount);
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