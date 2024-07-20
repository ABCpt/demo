using System;
using System.Collections.Generic;
using Core.Data;
using Core.Enemy.Data;
using Core.Enemy.Model;
using Core.Enemy.Services;
using Core.Level.Interface;
using Core.Projectile.Data;
using Core.Projectile.Model;
using Core.Projectile.Services;
using UnityEngine;

namespace Core.Projectile.Rules
{
    public class DamageProjectileOnEnemyRule : ILevelUpdatable
    {
        private readonly ProjectileService _projectileService;
        private readonly EnemiesService _enemiesService;
        private readonly EnemyConfig _enemyConfig;
        private readonly ProjectileConfig _projectileConfig;
        
        private List<ProjectileModel> _despawnProjectiles = new ();
        private IDisposable _updateStream;

        public DamageProjectileOnEnemyRule(ProjectileService projectileService, GameSettings gameSettings, EnemiesService enemiesService)
        {
            _projectileService = projectileService;
            _enemiesService = enemiesService;
            _enemyConfig = gameSettings.EnemyConfig;
            _projectileConfig = gameSettings.ProjectileConfig;
        }
        
        public void UpdateLevel()
        {
            foreach (var model in _projectileService.ProjectileModels)
            {
                var enemyModel = GetEnemyForDamage(model);
                if (enemyModel != null)
                {
                    _despawnProjectiles.Add(model);
                    _enemiesService.DamageEnemy(enemyModel, _projectileConfig.ProjectileDamage);
                }
            }
            
            foreach (var model in _despawnProjectiles)
            {
                _projectileService.DespawnProjectile(model);
            }
            
            _despawnProjectiles?.Clear();
        }

        private EnemyModel GetEnemyForDamage(ProjectileModel model)
        {
            var enemyModel = _enemiesService.GetNearEnemyByPosition(model.Position);
            
            if (enemyModel != null && Vector2.Distance(model.Position, enemyModel.Position) < _enemyConfig.EnemyRadius)
            {
                return enemyModel;
            }

            return null;
        }
    }
}
