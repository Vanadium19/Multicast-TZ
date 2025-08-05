using System;
using ComponentsModule;
using R3;
using Zenject;

namespace PlayerModule
{
    internal class PlayerPresenter : IInitializable, IDisposable
    {
        private readonly IDirectionMoveComponent _moveComponent;
        private readonly PlayerView _view;

        private IDisposable _disposable;

        public PlayerPresenter(IDirectionMoveComponent moveComponent, PlayerView view)
        {
            _moveComponent = moveComponent;
            _view = view;
        }

        public void Initialize()
        {
            var disposableBuilder = Disposable.CreateBuilder();

            _moveComponent.IsMoving.Subscribe(_view.SetMoving).AddTo(ref disposableBuilder);

            _disposable = disposableBuilder.Build();
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}