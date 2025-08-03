using FSMModule;

namespace BotModule
{
    public class IdleToMoveTransition : AbstractStateTransition<StateName>
    {
        private readonly Blackboard _blackboard;

        public IdleToMoveTransition(Blackboard blackboard)
            : base(StateName.Idle, StateName.Moving)
        {
            _blackboard = blackboard;
        }

        public override bool CanPerform()
        {
            return _blackboard.GetBool((int)BlackboardTag.IsStarted);
        }
    }
}