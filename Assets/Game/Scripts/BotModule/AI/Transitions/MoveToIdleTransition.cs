using FSMModule;

namespace BotModule
{
    internal class MoveToIdleTransition : AbstractStateTransition<StateName>
    {
        private readonly Blackboard _blackboard;
        private readonly int _key;

        public MoveToIdleTransition(Blackboard blackboard)
            : base(StateName.Moving, StateName.Idle)
        {
            _blackboard = blackboard;
            _key = (int)BlackboardTag.IsFinished;
        }

        public override bool CanPerform()
        {
            return _blackboard.HasBool(_key) && _blackboard.GetBool(_key);
        }
    }
}