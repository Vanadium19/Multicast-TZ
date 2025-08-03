using FSMModule;

namespace BotModule
{
    public class MoveToIdleTransition : AbstractStateTransition<StateName>
    {
        private readonly Blackboard _blackboard;

        public MoveToIdleTransition(Blackboard blackboard)
            : base(StateName.Moving, StateName.Idle)
        {
            _blackboard = blackboard;
        }

        public override bool CanPerform()
        {
            return _blackboard.GetBool((int)BlackboardTag.IsFinished);
        }
    }
}