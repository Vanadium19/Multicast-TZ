using FSMModule;

namespace BotModule
{
    internal class IdleState : IState
    {
        private readonly Blackboard _blackboard;
        private readonly IBot _bot;

        private readonly int _finishKey;

        public IdleState(Blackboard blackboard, IBot bot)
        {
            _blackboard = blackboard;
            _bot = bot;

            _finishKey = (int)BlackboardTag.IsFinished;
        }

        public void OnEnter()
        {
        }

        public void OnUpdate(float deltaTime)
        {
            if (_blackboard.TryGetBool(_finishKey, out bool value) && value)
                FinishWork();
        }

        public void OnExit()
        {
        }

        private void FinishWork()
        {
            _blackboard.SetBool(_finishKey, false);
            _bot.FinishWork();
        }
    }
}