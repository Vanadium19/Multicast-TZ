using Zenject;

namespace InventoryModule
{
    public class BagInstaller : Installer<BagView, BagInstaller>
    {
        private readonly BagView _bagView;

        public BagInstaller(BagView bagView)
        {
            _bagView = bagView;
        }

        public override void InstallBindings()
        {
            Container.Bind<IBag>()
                .To<Bag>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<BagPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<BagView>()
                .FromInstance(_bagView)
                .AsSingle();
        }
    }
}