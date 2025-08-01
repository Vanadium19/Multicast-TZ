using System.Collections.Generic;
using EntityModule;
using InstrumentsModule;
using UnityEngine;
using WalletModule;
using Zenject;

namespace RootModule
{
    public class SickleUpgradeController : MonoBehaviour
    {
        private IWallet _wallet;

        [Inject]
        public void Construct(IWallet wallet)
        {
            _wallet = wallet;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (entity.TryGet(out ISickle sickle))
                Upgrade(sickle);
        }

        private void Upgrade(IUpgradeable target)
        {
            if (!target.CanUpgrade)
                return;

            var price = target.Price;

            if (_wallet.Money.CurrentValue < price)
                return;

            _wallet.RemoveMoney(price);
            target.Upgrade();
        }
    }
}