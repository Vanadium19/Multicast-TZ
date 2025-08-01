using System;
using R3;
using Zenject;

namespace WalletModule
{
    internal class WalletPresenter : IInitializable, IDisposable
    {
        private readonly IWallet _wallet;
        private readonly WalletView _view;

        private IDisposable _disposables;

        public WalletPresenter(IWallet wallet, WalletView view)
        {
            _wallet = wallet;
            _view = view;
        }

        public void Initialize()
        {
            var disposableBuilder = Disposable.CreateBuilder();

            _wallet.Money.Subscribe(OnMoneyChanged).AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        private void OnMoneyChanged(int value)
        {
            var text = $"{value}";

            _view.UpdateMoney(text);
        }
    }
}