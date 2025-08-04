using System;
using R3;
using UnityEngine;

namespace BotModule
{
    public class Bot : IBot
    {
        private readonly ReactiveCommand _command;
        private readonly Blackboard _blackboard;

        public event Action ProductBought;
        public event Action<IBot> WorkFinished;

        public void BuyProduct()
        {
            ProductBought?.Invoke();
        }

        public void FinishWork()
        {
            WorkFinished?.Invoke(this);
        }
    }
}