using UnityEngine;
using Zenject;

namespace InstrumentsModule
{
    public class InstrumentsInstaller : Installer<SickleArgs, SickleView, UpgradeView, InstrumentsInstaller>
    {
        private readonly SickleArgs _sickleArgs;
        private readonly SickleView _sickleView;
        private readonly UpgradeView _upgradeView;

        public InstrumentsInstaller(SickleArgs sickleArgs,
            SickleView sickleView,
            UpgradeView upgradeView)
        {
            _sickleArgs = sickleArgs;
            _upgradeView = upgradeView;
            _sickleView = sickleView;
        }

        public override void InstallBindings()
        {
            SickleInstaller.Install(Container, _sickleArgs, _sickleView);

            Container.BindInterfacesTo<UpgradeSystemPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<UpgradeView>()
                .FromInstance(_upgradeView)
                .AsSingle();
        }
    }
}