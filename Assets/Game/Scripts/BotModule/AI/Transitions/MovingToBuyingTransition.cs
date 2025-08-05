using FSMModule;

namespace BotModule
{
    internal class MovingToBuyingTransition : AbstractStateTransition<StateName>
    {
        private readonly Blackboard _blackboard;
        private readonly int _key;

        public MovingToBuyingTransition(Blackboard blackboard)
            : base(StateName.Moving, StateName.Buying)
        {
            _blackboard = blackboard;
            _key = (int)BlackboardTag.IsBuying;
        }

        public override bool CanPerform()
        {
            return _blackboard.HasBool(_key) && _blackboard.GetBool(_key);
        }
    }
}