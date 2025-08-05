using EntityModule;
using PlayerModule;
using InstrumentsModule;
using R3;
using UnityEngine;
using WalletModule;
using Zenject;

namespace RootModule
{
    public class SickleUpgradeController : MonoBehaviour, IUpgradeSystem
    {
        private readonly ReactiveProperty<bool> _isActive = new();
        private readonly ReactiveProperty<int> _price = new();

        private IWallet _wallet;
        private ISickle _sickle;

        public ReadOnlyReactiveProperty<bool> IsActive => _isActive;
        public ReadOnlyReactiveProperty<float> Progress => _sickle.Progress;

        public ReadOnlyReactiveProperty<int> Price => _price;

        public bool CanBuy => _sickle.CanUpgrade && _wallet.Money.CurrentValue >= _sickle.Price;

        private void Awake()
        {
            UpdatePrice();
        }

        private void OnTriggerEnter(Collider other)
        {
            SetActive(other, true);
        }

        private void OnTriggerExit(Collider other)
        {
            SetActive(other, false);
        }

        [Inject]
        public void Construct(IWallet wallet, ISickle sickle)
        {
            _wallet = wallet;
            _sickle = sickle;
        }

        public void BuyUpgrade()
        {
            if (!CanBuy)
                return;

            var price = _sickle.Price;

            _wallet.RemoveMoney(price);
            _sickle.Upgrade();
            UpdatePrice();
        }

        private void UpdatePrice()
        {
            _price.Value = _sickle.Price;
        }

        private void SetActive(Collider other, bool value)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (!entity.TryGet(out Player player))
                return;

            _isActive.Value = value;
        }
    }
}