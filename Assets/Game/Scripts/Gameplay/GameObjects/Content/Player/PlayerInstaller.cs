using System;
using Gameplay.Core.Components;
using Gameplay.GameSystems.Controllers;
using UnityEngine;
using Zenject;

namespace Gameplay.Content.Player
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

            Container.Bind<IMoveComponent>()
                .To<MoveComponent>()
                .AsSingle()
                .WithArguments(_speed);

            Container.BindInterfacesTo<MoveController>()
                .AsSingle()
                .NonLazy();
        }
    }
}