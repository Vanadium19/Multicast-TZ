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

        private readonly float _minProgress;

        private readonly ReactiveCommand _chopped = new();
        private readonly ReactiveProperty<float> _progress = new();

        private float _radius;

        public Sickle(SickleArgs args)
        {
            _args = args;
            _layerMask = args.LayerMask;
            _radius = _args.StartRadius;

            _args.Transform.localScale = Vector3.one * _radius;
            _minProgress = 1f / (_args.MaxRadius - _args.StartRadius);
            _progress.Value = _minProgress;

            Chopped = _chopped.AsObservable();
        }

        public bool CanUpgrade => _radius < _args.MaxRadius;

        //Temporary solution
        public int Price => 5;
        public Observable<Unit> Chopped { get; }
        public ReadOnlyReactiveProperty<float> Progress => _progress;

        public IEnumerable<IGrass> Chop()
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

            _chopped.Execute(Unit.Default);
            arrayPool.Return(colliders);
            return grass;
        }

        public void Upgrade()
        {
            if (!CanUpgrade)
                return;

            _radius++;
            _args.Transform.localScale = Vector3.one * _radius;

            var progress = _radius.Remap(_args.StartRadius, _args.MaxRadius, _minProgress, 1);
            _progress.Value = progress;
        }
    }
}