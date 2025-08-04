using ComponentsModule;
using UnityEngine;
using Zenject;

namespace PlayerModule
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed = 5;

        public override void InstallBindings()
        {
            Container.Bind<Rigidbody>()
                .FromInstance(_rigidbody)
                .AsSingle();

            Container.Bind<Player>()
                .AsSingle()
                .NonLazy();

            Container.Bind<IDirectionMoveComponent>()
                .To<DirectionMoveComponent>()
                .AsSingle()
                .WithArguments(_speed);

            Container.BindInterfacesTo<MoveController>()
                .AsSingle()
                .NonLazy();
        }
    }
}