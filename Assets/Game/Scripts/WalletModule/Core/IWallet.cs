using R3;

namespace WalletModule
{
    public interface IWallet
    {
        public ReadOnlyReactiveProperty<int> Money { get; }
        public Observable<int> MoneyAdded { get; }

        public void AddMoney(int amount);
        public void RemoveMoney(int amount);
    }
}