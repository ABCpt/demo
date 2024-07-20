using System;
using Core.Data;
using Core.Enemy.Data;
using Core.Enemy.Services;
using Core.Level.Interface;
using Core.Level.Model;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Enemy.Rules
{
    public class SpawnEnemyRule : ILevelUpdatable
    {
        private readonly EnemiesService _enemiesService;
        private readonly EnemyConfig _enemyConfig;
        private readonly LevelModel _levelModel;
        
        private float _spawnTime;
        private IDisposable _updateStream;

        public SpawnEnemyRule(EnemiesService enemiesService, GameSettings gameSettings, LevelModel levelModel)
        {
            _enemiesService = enemiesService;
            _enemyConfig = gameSettings.EnemyConfig;
            _levelModel = levelModel;
        }

        public void UpdateLevel()
        {
            if (!_levelModel.IsAllEnemiesSpawned && Time.time >= _spawnTime)
            {
                SpawnEnemy();

                var deltaTime = Random.Range(_enemyConfig.MinSpawnTime, _enemyConfig.MaxSpawnTime);
                _spawnTime = Time.time + deltaTime;
            }
        }
        
        private void SpawnEnemy()
        {
            _enemiesService.SpawnEnemy();
        }
    }
}
