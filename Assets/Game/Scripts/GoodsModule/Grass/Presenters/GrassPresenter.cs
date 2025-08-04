using System;
using R3;
using Zenject;

namespace GoodsModule
{
    public class GrassPresenter : IInitializable, IDisposable
    {
        private readonly IGrass _grass;
        private readonly GrassView _view;

        private IDisposable _disposable;

        public GrassPresenter(IGrass grass, GrassView view)
        {
            _grass = grass;
            _view = view;
        }

        public void Initialize()
        {
            var builder = Disposable.CreateBuilder();

            _grass.IsCollected.Subscribe(OnGrassCollected).AddTo(ref builder);

            _disposable = builder.Build();
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }

        private void OnGrassCollected(bool isCollected)
        {
            if (isCollected)
                _view.SetCollectAnimation();
        }
    }
}