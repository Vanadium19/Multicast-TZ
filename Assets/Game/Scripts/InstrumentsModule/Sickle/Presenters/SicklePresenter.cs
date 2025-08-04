using System;
using R3;
using Zenject;

namespace InstrumentsModule
{
    public class SicklePresenter : IInitializable, IDisposable
    {
        private const int VFXStartProgress = 1;

        private readonly ISickle _sickle;
        private readonly SickleView _view;

        private IDisposable _disposable;

        public SicklePresenter(ISickle sickle, SickleView view)
        {
            _sickle = sickle;
            _view = view;
        }

        public void Initialize()
        {
            var builder = Disposable.CreateBuilder();

            _sickle.Progress.Skip(VFXStartProgress).Subscribe(_ => _view.SetUpgradeAnimation()).AddTo(ref builder);
            _sickle.Chopped.Subscribe(_ => _view.SetChoppingAnimation()).AddTo(ref builder);

            _disposable = builder.Build();
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}