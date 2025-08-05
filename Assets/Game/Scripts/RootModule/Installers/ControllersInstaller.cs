using Zenject;

namespace RootModule
{
    public class ControllersInstaller : Installer<CellController,
        SickleUpgradeController,
        SickleSwitchController,
        ControllersInstaller>
    {
        private readonly CellController _cellController;
        private readonly SickleUpgradeController _sickleUpgradeController;
        private readonly SickleSwitchController _sickleSwitchController;

        public ControllersInstaller(CellController cellController,
            SickleUpgradeController sickleUpgradeController,
            SickleSwitchController sickleSwitchController)
        {
            _cellController = cellController;
            _sickleUpgradeController = sickleUpgradeController;
            _sickleSwitchController = sickleSwitchController;
        }

        public override void InstallBindings()
        {
            Container.Bind<CellController>()
                .FromInstance(_cellController)
                .AsSingle();

            Container.BindInterfacesTo<SickleUpgradeController>()
                .FromInstance(_sickleUpgradeController)
                .AsSingle();

            Container.Bind<SickleSwitchController>()
                .FromInstance(_sickleSwitchController)
                .AsSingle();
        }
    }
}