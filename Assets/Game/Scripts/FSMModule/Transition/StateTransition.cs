﻿using System;

namespace Game.Modules.FSM
{
    public sealed class StateTransition<TKey> : IStateTransition<TKey>
    {
        private readonly Func<bool> _condition;

        public StateTransition(TKey from, TKey to, Func<bool> condition)
        {
            From = from;
            To = to;

            _condition = condition;
        }
        
        public TKey From { get; }
        public TKey To { get; }

        public bool CanPerform()
        {
            return _condition == null || _condition.Invoke();
        }
    }
}