using System;

namespace BotModule
{
    public interface IBot
    {
        public event Action ProductBought;
        public event Action<IBot> WorkFinished;
        public void BuyProduct();
        public void FinishWork();
    }
}