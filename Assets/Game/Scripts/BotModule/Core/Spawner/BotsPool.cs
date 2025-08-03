using EntityModule;
using UnityEngine;
using Zenject;

namespace BotModule
{
    public class BotsPool : MonoMemoryPool<Vector3, Entity>
    {
        protected override void Reinitialize(Vector3 position, Entity entity)
        {
            entity.transform.position = position;

            // var bot = entity.Get<Bot>();
            var blackboard = entity.Get<Blackboard>();

            blackboard.SetBool((int)BlackboardTag.IsStarted, true);
            blackboard.SetBool((int)BlackboardTag.IsFinished, false);
        }
    }
}