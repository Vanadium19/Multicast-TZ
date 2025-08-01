﻿using System;
using System.Collections.Generic;

namespace EntityModule
{
    public abstract class EntityComponent
    {
        private readonly List<Func<bool>> _conditions = new();

        public void AddCondition(Func<bool> condition)
        {
            _conditions.Add(condition);
        }

        public void RemoveCondition(Func<bool> condition)
        {
            _conditions.Remove(condition);
        }

        public bool CheckConditions()
        {
            foreach (var condition in _conditions)
            {
                if (!condition.Invoke())
                {
                    return false;
                }
            }

            return true;
        }
    }
}