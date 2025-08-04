using BotModule;
using EntityModule;
using UnityEngine;
using UnityEngine.Animations;
using Zenject;

namespace Installers
{
    public class BotSpawnerInstaller : MonoInstaller
    {
        private const string BotName = "Bot";
        private const float ConstraintWeight = 1f;

        [SerializeField] private Path _botPath;
        [SerializeField] private Entity _botPrefab;
        [SerializeField] private BotsSpawnerArgs _botsSpawnerArgs;
        [SerializeField] private Transform _canvasConstraintTransform;

        public override void InstallBindings()
        {
            Container.BindMemoryPool<Entity, BotPool>()
                .ExpandByOneAtATime()
                .FromComponentInNewPrefab(_botPrefab)
                .WithGameObjectName(BotName)
                .UnderTransform(_botsSpawnerArgs.SpawnPoint)
                .AsSingle();

            Container.Bind<IBotsSpawner>()
                .To<BotsSpawner>()
                .AsSingle()
                .WithArguments(_botsSpawnerArgs)
                .NonLazy();

            Container.Bind<Path>()
                .FromInstance(_botPath)
                .AsSingle();

            Container.Bind<ConstraintSource>()
                .FromMethod(CreateConstraintSource)
                .AsSingle();
        }

        private ConstraintSource CreateConstraintSource()
        {
            return new ConstraintSource { sourceTransform = _canvasConstraintTransform, weight = ConstraintWeight, };
        }
    }
}