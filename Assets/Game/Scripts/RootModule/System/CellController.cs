using EntityModule;
using InvetoryModule;
using PlayerModule;
using UnityEngine;
using WalletModule;
using Zenject;

namespace RootModule
{
    public class CellController : MonoBehaviour
    {
        private IWallet _wallet;
        private IBag _bag;

        [Inject]
        public void Construct(IWallet wallet, IBag bag)
        {
            _wallet = wallet;
            _bag = bag;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (entity.TryGet(out Player player))
                Cell();
        }

        private void Cell()
        {
            var cost = _bag.GoodsCost;

            _wallet.AddMoney(cost);
            _bag.Clear();
        }
    }
}