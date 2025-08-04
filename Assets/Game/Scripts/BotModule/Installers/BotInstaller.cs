using System.Collections.Generic;
using BotModule;
using ComponentsModule;
using FSMModule;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class BotInstaller : MonoInstaller
    {
        [SerializeField] private Transform _bot;
        [SerializeField] private float _speed = 5f;

        public override void InstallBindings()
        {
            Container.Bind<IBot>()
                .To<Bot>()
                .AsSingle();

            Container.Bind<ITargetMoveComponent>()
                .To<TargetMoveComponent>()
                .AsSingle()
                .WithArguments(_speed)
                .NonLazy();

            Container.Bind<Transform>()
                .FromInstance(_bot)
                .AsSingle();

            Container.Bind<Blackboard>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<AIAgent>()
                .AsSingle()
                .NonLazy();

            Container.Bind<IStateMachine<StateName>>()
                .FromMethod(CreateStateMachine);
        }

        private IStateMachine<StateName> CreateStateMachine(InjectContext context)
        {
            var container = context.Container;

            return new AutoStateMachine<StateName>(StateName.Idle,
                new List<(StateName, IState)>
                {
                    (StateName.Idle, container.Instantiate<IdleState>()),
                    (StateName.Moving, container.Instantiate<MovingState>()),
                    (StateName.Buying, container.Instantiate<BuyingState>()),
                },
                new List<IStateTransition<StateName>>
                {
                    container.Instantiate<IdleToMoveTransition>(),
                    container.Instantiate<MoveToIdleTransition>(),
                    container.Instantiate<MovingToBuyingTransition>(),
                    container.Instantiate<BuyingToMovingTransition>(),
                });
        }
    }
}