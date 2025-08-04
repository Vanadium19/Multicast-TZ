using System;
using R3;

namespace BotModule
{
    public interface IBot
    {
        public event Action<IBot> WorkFinished;

        public Observable<Unit> ProductBought { get; }
        public ReadOnlyReactiveProperty<bool> IsMoving { get; }

        public void BuyProduct();
        public void FinishWork();
    }
}