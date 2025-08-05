using EntityModule;
using UnityEngine;
using Zenject;

namespace BotModule
{
    internal class BotPool : MonoMemoryPool<Vector3, Entity>
    {
        protected override void Reinitialize(Vector3 position, Entity entity)
        {
            entity.gameObject.SetActive(true);
            entity.transform.position = position;

            var blackboard = entity.Get<Blackboard>();
            blackboard.SetBool((int)BlackboardTag.IsStarted, true);
        }

        protected override void OnDespawned(Entity entity)
        {
            entity.gameObject.SetActive(false);

            var blackboard = entity.Get<Blackboard>();
            blackboard.SetBool((int)BlackboardTag.IsFinished, false);
            blackboard.SetBool((int)BlackboardTag.IsStarted, false);
        }
    }
}