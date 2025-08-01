using Zenject;

namespace RootModule
{
    public class ControllersInstaller : Installer<CellController, SickleUpgradeController, ControllersInstaller>
    {
        private readonly CellController _cellController;
        private readonly SickleUpgradeController _sickleUpgradeController;

        public ControllersInstaller(CellController cellController, SickleUpgradeController sickleUpgradeController)
        {
            _cellController = cellController;
            _sickleUpgradeController = sickleUpgradeController;
        }

        public override void InstallBindings()
        {
            Container.Bind<CellController>()
                .FromInstance(_cellController)
                .AsSingle();

            Container.Bind<SickleUpgradeController>()
                .FromInstance(_sickleUpgradeController)
                .AsSingle();
        }
    }
}