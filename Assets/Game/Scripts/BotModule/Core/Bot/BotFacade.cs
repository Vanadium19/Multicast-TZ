using System;
using ComponentsModule;
using R3;

namespace BotModule
{
    internal class BotFacade : IBot
    {
        private readonly ITargetMoveComponent _moveComponent;
        private readonly Blackboard _blackboard;

        private readonly ReactiveCommand _buyingCommand = new();

        public event Action<IBot> WorkFinished;

        public BotFacade(ITargetMoveComponent moveComponent)
        {
            _moveComponent = moveComponent;
            ProductBought = _buyingCommand.AsObservable();
        }

        public Observable<Unit> ProductBought { get; }
        public ReadOnlyReactiveProperty<bool> IsMoving => _moveComponent.IsMoving;

        public void BuyProduct()
        {
            _buyingCommand.Execute(Unit.Default);
        }

        public void FinishWork()
        {
            WorkFinished?.Invoke(this);
        }
    }
}