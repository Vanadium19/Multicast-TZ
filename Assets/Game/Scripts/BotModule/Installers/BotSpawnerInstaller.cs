using BotModule;
using EntityModule;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class BotSpawnerInstaller : MonoInstaller
    {
        private const string BotName = "Bot";

        [SerializeField] private Path _botPath;
        [SerializeField] private Entity _botPrefab;
        [SerializeField] private BotsSpawnerArgs _botsSpawnerArgs;

        public override void InstallBindings()
        {
            Container.BindMemoryPool<Entity, BotsPool>()
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
        }
    }
}