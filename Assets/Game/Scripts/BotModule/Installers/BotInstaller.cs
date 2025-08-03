using System.Collections.Generic;
using BotModule;
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
                    (StateName.Idle, new BaseState()),
                    (StateName.Moving, container.Instantiate<MovingState>(new object[] { _speed })),
                },
                new List<IStateTransition<StateName>>
                {
                    container.Instantiate<IdleToMoveTransition>(),
                    container.Instantiate<MoveToIdleTransition>(),
                });
        }
    }
}