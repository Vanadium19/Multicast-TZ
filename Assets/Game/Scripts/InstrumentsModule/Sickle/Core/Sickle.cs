using System.Collections.Generic;
using EntityModule;
using GoodsModule;
using R3;
using UnityEngine;
using UtilsModule;

namespace InstrumentsModule
{
    public class Sickle : ISickle
    {
        private const int ColliderBufferSize = 32;

        private readonly SickleArgs _args;
        private readonly int _layerMask;

        private readonly ReactiveProperty<float> _progress = new();

        private float _radius;

        public Sickle(SickleArgs args)
        {
            _args = args;
            _layerMask = args.LayerMask;
            _radius = _args.StartRadius;
        }

        public bool CanUpgrade => _radius < _args.MaxRadius;

        //Temporary solution
        public int Price => 5;
        public ReadOnlyReactiveProperty<float> Progress => _progress;

        public IEnumerable<IGrass> CollectGrass()
        {
            var grass = new List<IGrass>();

            var arrayPool = System.Buffers.ArrayPool<Collider>.Shared;
            var colliders = arrayPool.Rent(ColliderBufferSize);

            var count = Physics.OverlapSphereNonAlloc(_args.Point, _radius, colliders, _layerMask);

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

        public void Upgrade()
        {
            if (!CanUpgrade)
                return;

            _radius++;

            var progress = _radius.Remap(_args.StartRadius, _args.MaxRadius, 0, 1);
            _progress.Value = progress;

            _args.RadiusForGizmos = _radius;
        }
    }
}