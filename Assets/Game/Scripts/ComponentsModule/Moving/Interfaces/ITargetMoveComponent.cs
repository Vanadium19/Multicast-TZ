using System.Threading;
using DG.Tweening;
using UnityEngine;

namespace ComponentsModule
{
    public interface ITargetMoveComponent : IMoveComponent
    {
        public Tween MoveToTarget(Vector3 position, CancellationToken cancellationToken = default);
    }
}