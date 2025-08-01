using UnityEngine;
using WalletModule;
using Zenject;

namespace RootModule
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Wallet")] [SerializeField] private WalletView _walletView;

        [Header("CellPoint")] [SerializeField] private CellController _cellController;

        [Header("UpgradePoint")] [SerializeField] private SickleUpgradeController _sickleUpgradeController;

        public override void InstallBindings()
        {
            InputInstaller.Install(Container);
            ControllersInstaller.Install(Container, _cellController, _sickleUpgradeController);
            WalletInstaller.Install(Container, _walletView);
        }
    }
}