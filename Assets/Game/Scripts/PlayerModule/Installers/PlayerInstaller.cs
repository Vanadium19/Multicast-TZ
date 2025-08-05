using ComponentsModule;
using UnityEngine;
using Zenject;

namespace PlayerModule
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerView _view;
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed = 5;

        public override void InstallBindings()
        {
            Container.Bind<Rigidbody>()
                .FromInstance(_rigidbody)
                .AsSingle();

            Container.Bind<Transform>()
                .FromInstance(_transform)
                .AsSingle();

            Container.Bind<Player>()
                .AsSingle()
                .NonLazy();

            Container.Bind<IDirectionMoveComponent>()
                .To<DirectionMoveComponent>()
                .AsSingle()
                .WithArguments(_speed);

            Container.Bind<IRotationComponent>()
                .To<RotationComponent>()
                .AsSingle();

            Container.BindInterfacesTo<MoveController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<PlayerPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<PlayerView>()
                .FromInstance(_view)
                .AsSingle();
        }
    }
}