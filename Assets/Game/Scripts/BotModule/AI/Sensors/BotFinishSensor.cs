using EntityModule;
using UnityEngine;

namespace BotModule
{
    public class BotFinishSensor : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (!entity.TryGet(out Blackboard blackboard))
                return;

            blackboard.SetBool((int)BlackboardTag.IsFinished, true);
        }
    }
}