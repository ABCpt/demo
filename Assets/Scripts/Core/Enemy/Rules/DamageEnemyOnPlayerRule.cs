using System.Collections.Generic;
using Core.Data;
using Core.Enemy.Data;
using Core.Enemy.Model;
using Core.Enemy.Services;
using Core.Level.Data;
using Core.Level.Interface;
using Core.Player.Data;
using Core.Player.Model;

namespace Core.Enemy.Rules
{
    public class DamageEnemyOnPlayerRule : ILevelUpdatable
    {
        private readonly EnemiesService _enemiesService;
        private readonly PlayerModel _playerModel;
        
        private readonly LevelConfig _levelConfig;
        private readonly PlayerConfig _playerConfig;
        private readonly EnemyConfig _enemyConfig;
        
        private List<EnemyModel> _despawnEnemies = new ();

        public DamageEnemyOnPlayerRule(GameSettings gameSettings, EnemiesService enemiesService, PlayerModel playerModel)
        {
            _enemiesService = enemiesService;
            _playerModel = playerModel;
            _levelConfig = gameSettings.LevelConfig;
            _playerConfig = gameSettings.PlayerConfig;
            _enemyConfig = gameSettings.EnemyConfig;
        }
        
        public void UpdateLevel()
        {
            foreach (var model in _enemiesService.EnemyModels)
            {
                if (IsDamageArea(model))
                {
                    _playerModel.Damage(_enemyConfig.Damage);
                    _despawnEnemies.Add(model);
                }
            }
            
            foreach (var model in _despawnEnemies)
            {
                _enemiesService.DespawnEnemy(model);
            }
            
            _despawnEnemies?.Clear();
        }

        private bool IsDamageArea(EnemyModel model)
        {
            return model.Position.y < -_levelConfig.CameraSize 
                   + _playerConfig.PlayerSize.y / 2 
                   + _levelConfig.MoveAreaHeight;
        }
    }
}
