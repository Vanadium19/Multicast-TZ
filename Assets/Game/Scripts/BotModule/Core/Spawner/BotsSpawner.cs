using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using EntityModule;
using UnityEngine;

namespace BotModule
{
    public class BotsSpawner : IBotsSpawner
    {
        private readonly Dictionary<IBot, Entity> _bots = new();

        private readonly BotsSpawnerArgs _args;
        private readonly BotsPool _botsPool;

        private bool _isSpawning;
        private int _botsCount;

        public BotsSpawner(BotsPool botsPool,
            BotsSpawnerArgs args)
        {
            _botsPool = botsPool;
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
                Spawn();
            }

            _isSpawning = false;
        }

        private void Spawn()
        {
            _botsCount--;

            var spawnPosition = _args.SpawnPosition;
            var entity = _botsPool.Spawn(spawnPosition);
            var bot = entity.Get<IBot>();

            bot.WorkFinished += OnWorkFinished;
            _bots.Add(bot, entity);
        }

        private void OnWorkFinished(Bot bot)
        {
            if (_bots.Remove(bot, out var entity))
                _botsPool.Despawn(entity);

            bot.WorkFinished -= OnWorkFinished;
        }
    }
}