using System;
using Cysharp.Threading.Tasks;
using FSMModule;

namespace BotModule
{
    public class BuyingState : IState
    {
        private readonly IBot _bot;

        public BuyingState(IBot bot)
        {
            _bot = bot;
        }

        public void OnEnter()
        {
            _bot.BuyProduct();
        }

        public void OnUpdate(float deltaTime)
        {
        }

        public void OnExit()
        {
        }
    }
}