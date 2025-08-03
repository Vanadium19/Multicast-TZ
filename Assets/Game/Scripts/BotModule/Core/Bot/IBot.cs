using System;

namespace BotModule
{
    public interface IBot
    {
        public event Action<Bot> WorkFinished;
        public void FinishWork();
    }
}