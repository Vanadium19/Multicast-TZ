using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using EntityModule;

namespace BotModule
{
    internal class BotsSpawner : IBotsSpawner
    {
        private readonly Dictionary<IBot, Entity> _bots = new();

        private readonly BotsSpawnerArgs _args;
        private readonly PathPoint _firstPoint;
        private readonly BotPool _botPool;

        private bool _isSpawning;
        private int _botsCount;

        public BotsSpawner(BotPool botPool,
            BotsSpawnerArgs args,
            Path path)
        {
            _firstPoint = path.GetFirstPoint();
            _botPool = botPool;
            _args = args;
        }

        public void AddCount(int value)
        {
            if (value <= 0)
                return;

            _botsCount += value;

            if (!_isSpawning)
                StartSpawning().Forget();
        }

        private async UniTaskVoid StartSpawning()
        {
            var delay = _args.Delay;
            _isSpawning = true;

            while (_botsCount > 0)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(delay));
                await UniTask.WaitWhile(() => _firstPoint.IsBusy);
                Spawn();
            }

            _isSpawning = false;
        }

        private void Spawn()
        {
            _botsCount--;

            var spawnPosition = _args.SpawnPosition;
            var entity = _botPool.Spawn(spawnPosition);
            var bot = entity.Get<IBot>();

            bot.WorkFinished += OnWorkFinished;
            _bots.Add(bot, entity);
        }

        private void OnWorkFinished(IBot bot)
        {
            if (_bots.Remove(bot, out var entity))
                _botPool.Despawn(entity);

            bot.WorkFinished -= OnWorkFinished;
        }
    }
}