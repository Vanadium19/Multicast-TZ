using Zenject;

namespace InstrumentsModule
{
    public class SickleInstaller : Installer<SickleArgs, SickleView, SickleInstaller>
    {
        private readonly SickleArgs _sickleArgs;
        private readonly SickleView _sickleView;

        public SickleInstaller(SickleArgs sickleArgs, SickleView sickleView)
        {
            _sickleArgs = sickleArgs;
            _sickleView = sickleView;
        }

        public override void InstallBindings()
        {
            Container.Bind<ISickle>()
                .To<Sickle>()
                .AsSingle()
                .WithArguments(_sickleArgs);

            Container.BindInterfacesTo<HarvestController>()
                .AsSingle()
                .WithArguments(_sickleArgs.Delay)
                .NonLazy();

            Container.BindInterfacesTo<SicklePresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<SickleView>()
                .FromInstance(_sickleView)
                .AsSingle();
        }
    }
}