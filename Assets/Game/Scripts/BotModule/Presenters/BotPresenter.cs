using System;
using R3;
using Zenject;

namespace BotModule
{
    public class BotPresenter : IInitializable, IDisposable
    {
        private readonly IBot _bot;
        private readonly BotView _view;

        private IDisposable _disposable;

        public BotPresenter(IBot bot, BotView view)
        {
            _view = view;
            _bot = bot;
        }

        public void Initialize()
        {
            var disposableBuilder = Disposable.CreateBuilder();

            _bot.IsMoving.Subscribe(_view.SetMoving).AddTo(ref disposableBuilder);
            _bot.ProductBought.Subscribe(_ => _view.SetBuyingAnimation()).AddTo(ref disposableBuilder);

            _disposable = disposableBuilder.Build();
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}