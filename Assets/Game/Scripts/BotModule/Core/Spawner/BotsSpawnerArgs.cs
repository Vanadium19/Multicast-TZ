using System;
using UnityEngine;

namespace BotModule
{
    [Serializable]
    public class BotsSpawnerArgs
    {
        [SerializeField] private float _delay;
        [SerializeField] private Transform _spawnPoint;

        public float Delay => _delay;
        public Vector3 SpawnPosition => _spawnPoint.position;
        public Transform SpawnPoint => _spawnPoint;
    }
}