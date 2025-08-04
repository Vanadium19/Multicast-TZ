using UnityEngine;
using Zenject;

namespace GoodsModule
{
    public class GrassInstaller : MonoInstaller
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private GoodConfig _goodConfig;
        [SerializeField] private GrassView _view;

        public override void InstallBindings()
        {
            Container.Bind<Collider>()
                .FromInstance(_collider)
                .AsSingle();

            Container.Bind<GoodConfig>()
                .FromInstance(_goodConfig)
                .AsSingle();

            Container.Bind<IGrass>()
                .To<Grass>()
                .AsSingle();

            Container.BindInterfacesTo<GrassPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<GrassView>()
                .FromInstance(_view)
                .AsSingle();
        }
    }
}