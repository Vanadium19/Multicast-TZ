using Zenject;

namespace InstrumentsModule
{
    public class SickleInstaller : Installer<SickleArgs, SickleInstaller>
    {
        private readonly SickleArgs _sickleArgs;

        public SickleInstaller(SickleArgs sickleArgs)
        {
            _sickleArgs = sickleArgs;
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
        }
    }
}