using System;
using R3;
using Zenject;

namespace InstrumentsModule
{
    public class UpgradeSystemPresenter : IInitializable, IDisposable
    {
        private readonly IUpgradeSystem _upgradeSystem;
        private readonly UpgradeView _view;

        private IDisposable _disposable;

        public UpgradeSystemPresenter(IUpgradeSystem upgradeSystem, UpgradeView view)
        {
            _upgradeSystem = upgradeSystem;
            _view = view;
        }

        public void Initialize()
        {
            _view.Initialize();

            var builder = Disposable.CreateBuilder();

            _upgradeSystem.IsActive.Subscribe(OnUpgradeSystemActivated).AddTo(ref builder);
            _upgradeSystem.Price.Subscribe(OnPriceChanged).AddTo(ref builder);

            _view.BuyButtonClicked.Subscribe(_ => OnBuyButtonClicked()).AddTo(ref builder);

            _disposable = builder.Build();
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        private void OnUpgradeSystemActivated(bool isActive)
        {
            _view.Enable(isActive);
            UpdateButton();
        }

        private void OnBuyButtonClicked()
        {
            _upgradeSystem.BuyUpgrade();

            UpdateButton();
        }

        private void OnPriceChanged(int price)
        {
            var text = $"{price}$";

            _view.UpgradePrice(text);
        }

        private void UpdateButton()
        {
            _view.UpdateButton(_upgradeSystem.CanBuy);
        }
    }
}