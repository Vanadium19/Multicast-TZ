using System;
using Cysharp.Threading.Tasks;
using EntityModule;
using UnityEngine;

namespace BotModule
{
    internal class ShopPlaceSensor : MonoBehaviour
    {
        [SerializeField] private float _buyDelay = 2f;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity))
                return;

            if (!entity.TryGet(out Blackboard blackboard))
                return;

            StartBuying(blackboard).Forget();
        }

        private async UniTaskVoid StartBuying(Blackboard blackboard)
        {
            blackboard.SetBool((int)BlackboardTag.IsBuying, true);

            await UniTask.Delay(TimeSpan.FromSeconds(_buyDelay));

            blackboard.SetBool((int)BlackboardTag.IsBuying, false);
        }
    }
}