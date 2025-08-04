using FSMModule;

namespace BotModule
{
    public class BuyingToMovingTransition : AbstractStateTransition<StateName>
    {
        private readonly Blackboard _blackboard;
        private readonly int _key;

        public BuyingToMovingTransition(Blackboard blackboard)
            : base(StateName.Buying, StateName.Moving)
        {
            _blackboard = blackboard;
            _key = (int)BlackboardTag.IsBuying;
        }

        public override bool CanPerform()
        {
            return _blackboard.HasBool(_key) && !_blackboard.GetBool(_key);
        }
    }
}