using EntityModule;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BotModule
{
    public class BotSensor : MonoBehaviour
    {
        [SerializeField] private Entity _entity;

        private Blackboard _blackboard;

        private void Start()
        {
            _blackboard = _entity.Get<Blackboard>();

            SetStarted(false);
            SetFinished(false);
        }

        [Button]
        public void SetStarted(bool value)
        {
            _blackboard.SetBool((int)BlackboardTag.IsStarted, value);
        }

        [Button]
        public void SetFinished(bool value)
        {
            _blackboard.SetBool((int)BlackboardTag.IsFinished, value);
        }
    }
}