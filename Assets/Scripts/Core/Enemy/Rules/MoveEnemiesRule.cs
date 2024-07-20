using System;
using Core.Enemy.Model;
using Core.Enemy.Services;
using Core.Level.Interface;

namespace Core.Enemy.Rules
{
    public class MoveEnemiesRule : ILevelUpdatable
    {
        private readonly EnemiesService _enemiesService;
        private IDisposable _updateStream;
        
        public MoveEnemiesRule(EnemiesService enemiesService)
        {
            _enemiesService = enemiesService;
        }

        private void MoveEnemy(EnemyModel model)
        {
            model.Move();
        }

        public void UpdateLevel()
        {
            foreach (var model in _enemiesService.EnemyModels)
            {
                MoveEnemy(model);
            }
        }
    }
}
