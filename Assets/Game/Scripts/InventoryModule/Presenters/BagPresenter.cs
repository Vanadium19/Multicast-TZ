using System;
using R3;
using Zenject;

namespace InventoryModule
{
    public class BagPresenter : IInitializable, IDisposable
    {
        private readonly IBag _bag;
        private readonly BagView _view;

        private IDisposable _disposables;

        public BagPresenter(IBag bag, BagView view)
        {
            _bag = bag;
            _view = view;
        }

        public void Initialize()
        {
            var disposableBuilder = Disposable.CreateBuilder();

            _bag.GoodsCount.Subscribe(OnGoogsCountChanged).AddTo(ref disposableBuilder);

            _disposables = disposableBuilder.Build();
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        private void OnGoogsCountChanged(int value)
        {
            var text = $"{value}";

            _view.UpdateCount(text);
        }
    }
}