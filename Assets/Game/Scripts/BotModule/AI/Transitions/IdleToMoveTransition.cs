using FSMModule;

namespace BotModule
{
    internal class IdleToMoveTransition : AbstractStateTransition<StateName>
    {
        private readonly Blackboard _blackboard;
        private readonly int _key;

        public IdleToMoveTransition(Blackboard blackboard)
            : base(StateName.Idle, StateName.Moving)
        {
            _blackboard = blackboard;
            _key = (int)BlackboardTag.IsStarted;
        }

        public override bool CanPerform()
        {
            return _blackboard.HasBool(_key) && _blackboard.GetBool(_key);
        }
    }
}