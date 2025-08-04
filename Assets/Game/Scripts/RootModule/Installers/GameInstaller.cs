using InstrumentsModule;
using InventoryModule;
using UnityEngine;
using WalletModule;
using Zenject;

namespace RootModule
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Bag")] [SerializeField] private BagView _bagView;

        [Header("Wallet")] [SerializeField] private WalletView _walletView;

        [Header("Instruments")] [SerializeField] private SickleArgs _sickleArgs;
        [SerializeField] private SickleView _sickleView;
        [SerializeField] private UpgradeView _upgradeView;

        [Header("CellPoint")] [SerializeField] private CellController _cellController;

        [Header("UpgradePoint")] [SerializeField] private SickleUpgradeController _sickleUpgradeController;

        [Header("GrassField")] [SerializeField] private SickleSwitchController _sickleSwitchController;

        public override void InstallBindings()
        {
            InputInstaller.Install(Container);
            ControllersInstaller.Install(Container, _cellController, _sickleUpgradeController, _sickleSwitchController);
            WalletInstaller.Install(Container, _walletView);
            BagInstaller.Install(Container, _bagView);
            InstrumentsInstaller.Install(Container, _sickleArgs, _sickleView, _upgradeView);
        }
    }
}