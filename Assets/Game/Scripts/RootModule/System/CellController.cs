using EntityModule;
using InvetoryModule;
using UnityEngine;
using WalletModule;
using Zenject;

namespace RootModule
{
    public class CellController : MonoBehaviour
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

            if (entity.TryGet(out IBag bag))
                Cell(bag);
        }

        private void Cell(IBag bag)
        {
            var cost = bag.GoodsCost;

            _wallet.AddMoney(cost);
            bag.Clear();
        }
    }
}