using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Enemy.Model;
using Core.Level.Interface;
using Core.Level.Model;
using UnityEngine;

namespace Core.Enemy.Services
{
    public class EnemiesService : ILevelFinishable
    {
        private readonly EnemyFactory _enemyFactory;
        private readonly List<Vector2> _spawnPoints = new List<Vector2>();
        private readonly LevelModel _levelModel;

        public List<EnemyModel> EnemyModels { get; private set; }  = new List<EnemyModel>();

        public EnemiesService(EnemyFactory enemyFactory, LevelModel levelModel)
        {
            _enemyFactory = enemyFactory;
            _levelModel = levelModel;
        }

        public void SpawnEnemy()
        {
            var position = GetRandomEnemySpawnPoint();
            var model = _enemyFactory.Spawn(position);
            EnemyModels.Add(model);
            _levelModel.SpawnEnemy();
        }
        
        private Vector2 GetRandomEnemySpawnPoint()
        {
            if (_spawnPoints.Count > 0)
            {
                var randomIndex = Random.Range(0, _spawnPoints.Count);
                return _spawnPoints[randomIndex];
            }

            return Vector2.zero;
        }

        public void DespawnEnemy(EnemyModel model)
        {
            if (EnemyModels.Contains(model))
                EnemyModels.Remove(model);
            
            _enemyFactory.Despawn(model);
            _levelModel.DestroyEnemy();
        }

        public void DamageEnemy(EnemyModel model, int damage)
        {
            model.Damage(damage);
            
            if(model.IsDead)
                DespawnEnemy(model);
        }

        public void AddSpawnPoint(Vector2 spawnPoint)
        {
            if (!_spawnPoints.Contains(spawnPoint))
                _spawnPoints.Add(spawnPoint);
        }

        public EnemyModel GetNearEnemyByPosition(Vector2 postion)
        {
            EnemyModel enemyModel = null;

            var minDistance = float.MaxValue;
            
            foreach (var model in EnemyModels)
            {
                var distance = Vector2.Distance(postion, model.Position);
                if (distance < minDistance)
                {
                    enemyModel = model;
                    minDistance = distance;
                }
            }

            return enemyModel;
        }

        public async void FinishLevel()
        {
            await Task.Yield();
            
            foreach (var enemyModel in EnemyModels)
            {
                _enemyFactory.Despawn(enemyModel);
            }
            EnemyModels?.Clear();
        }
    }
}
