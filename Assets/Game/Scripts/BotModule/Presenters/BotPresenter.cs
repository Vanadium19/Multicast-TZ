using System;
using ComponentsModule;
using R3;
using Zenject;

namespace BotModule
{
    public class BotPresenter : IInitializable, IDisposable
    {
        private readonly ITargetMoveComponent _moveComponent;
        private readonly BotView _view;

        private IDisposable _disposable;

        public BotPresenter(ITargetMoveComponent moveComponent, BotView view)
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