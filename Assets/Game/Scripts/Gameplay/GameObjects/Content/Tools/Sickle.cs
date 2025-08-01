using System.Collections.Generic;
using Game.Modules.EntityModule;
using Gameplay.Content.Goods;
using UnityEngine;

namespace Gameplay.Content.Tools
{
    public class Sickle : ISickle
    {
        private const int ColliderBufferSize = 32;

        private readonly SickleArgs _args;
        private readonly int _layerMask;

        public Sickle(SickleArgs args)
        {
            _args = args;
            _layerMask = args.LayerMask;
        }

        public IEnumerable<IGrass> CollectGrass()
        {
            var grass = new List<IGrass>();

            var arrayPool = System.Buffers.ArrayPool<Collider>.Shared;
            var colliders = arrayPool.Rent(ColliderBufferSize);

            var count = Physics.OverlapSphereNonAlloc(_args.Point, _args.Radius, colliders, _layerMask);

            for (int i = 0; i < count; i++)
            {
                var collider = colliders[i];

                if (!collider.TryGetComponent(out IEntity entity))
                    continue;

                if (!entity.TryGet(out IGrass target))
                    continue;

                grass.Add(target);
                target.Collect();
            }

            arrayPool.Return(colliders);
            return grass;
        }
    }
}