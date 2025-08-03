using System;

namespace BotModule
{
    public class Bot : IBot
    {
        public event Action<Bot> WorkFinished;

        public void FinishWork()
        {
            WorkFinished?.Invoke(this);
        }
    }
}