using Zenject;

namespace WalletModule
{
    public class WalletInstaller : Installer<WalletView, WalletInstaller>
    {
        private readonly WalletView _view;

        public WalletInstaller(WalletView view)
        {
            _view = view;
        }

        public override void InstallBindings()
        {
            Container.Bind<IWallet>()
                .To<Wallet>()
                .AsSingle();

            Container.BindInterfacesTo<WalletPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<WalletView>()
                .FromInstance(_view)
                .AsSingle();
        }
    }
}