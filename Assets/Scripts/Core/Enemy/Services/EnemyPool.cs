using Common.Pool.Services;
using Core.Data;
using Core.Enemy.Data;
using Core.Enemy.View;
using UnityEngine;
using Zenject;

namespace Core.Enemy.Services
{
    public class EnemyPool : BasePool<EnemyView>
    {
        private readonly EnemyConfig _enemyConfig;
        
        public EnemyPool(DiContainer diContainer, GameSettings gameSettings) : base(diContainer)
        {
            _enemyConfig = gameSettings.EnemyConfig;
        }

        protected override GameObject GetPrefab()
        {
            return _enemyConfig.EnemyPrefab.gameObject;
        }
    }
}