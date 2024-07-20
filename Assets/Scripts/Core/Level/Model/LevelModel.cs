using System;
using Core.Data;
using Core.Level.Data;
using Core.Level.Interface;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Level.Model
{
    public class LevelModel : ILevelStartable
    {
        public event Action LevelCompleted = delegate {  };
        public bool IsAllEnemiesSpawned => _spawnedEnemiesCount >= _maxEnemies;
        private bool _isLevelCompleted => IsAllEnemiesSpawned && _spawnedEnemiesCount == _destroyedEnemiesCount;
        
        private readonly LevelConfig _levelConfig;
        
        private int _maxEnemies;
        private int _spawnedEnemiesCount;
        private int _destroyedEnemiesCount;

        public LevelModel(GameSettings gameSettings)
        {
            _levelConfig = gameSettings.LevelConfig;
        }

        public void SpawnEnemy()
        {
            _spawnedEnemiesCount++;
        }
        
        public void DestroyEnemy()
        {
            _destroyedEnemiesCount++;
            
            if (_isLevelCompleted)
                LevelCompleted?.Invoke();
        }

        public void StartLevel()
        {
            _maxEnemies = Random.Range(_levelConfig.MinEnemies, _levelConfig.MaxEnemies);

            _spawnedEnemiesCount = 0;
            _destroyedEnemiesCount = 0;
        }

        public void Finish()
        {
            
        }
    }
}
