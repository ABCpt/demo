using System.Collections.Generic;
using System.Linq;
using Core.Enemy.Model;
using Core.Enemy.View;
using UnityEngine;
using Zenject;

namespace Core.Enemy.Services
{
    public class EnemyFactory
    {
        private readonly DiContainer _diContainer;
        private readonly EnemyPool _effectsPool;

        private readonly List<EnemyView> _enemyViews = new List<EnemyView>();

        public EnemyFactory(EnemyPool effectsPool, DiContainer diContainer)
        {
            _effectsPool = effectsPool;
            _diContainer = diContainer;
        }

        public EnemyModel Spawn(Vector2 position)
        {
            var model = _diContainer.Resolve<EnemyModel>();
            model.SetPosition(position);
            
            var enemyView = _effectsPool.Spawn(typeof(EnemyView).FullName);

            if (enemyView == null)
            {
                Debug.LogError("There is no item with id " + typeof(EnemyView).FullName);
                return null;
            }

            enemyView.Initialize(model);
            _enemyViews.Add(enemyView);
            
            return model;
        }

        public void Despawn(EnemyModel model)
        {
            var enemyView = _enemyViews.FirstOrDefault(data => data.Model == model);
            
            if (enemyView != null)
                _effectsPool.Despawn(enemyView, typeof(EnemyView).FullName);
        }
    }
}
