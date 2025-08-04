using BotModule;
using EntityModule;
using InventoryModule;
using PlayerModule;
using UnityEngine;
using WalletModule;
using Zenject;

namespace RootModule
{
    public class CellController : MonoBehaviour
    {
        private IBotsSpawner _botSpawner;
        private IWallet _wallet;
        private IBag _bag;

        [Inject]
        public void Construct(IBotsSpawner botSpawner, IWallet wallet, IBag bag)
        {
            _botSpawner = botSpawner;
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
            var count = _bag.GoodsCount.CurrentValue;

            _wallet.AddMoney(cost);

            _botSpawner.AddCount(count);
            _bag.Clear();
        }
    }
}