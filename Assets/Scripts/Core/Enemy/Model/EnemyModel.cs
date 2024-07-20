using System;
using Core.Data;
using Core.Enemy.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Enemy.Model
{
    public class EnemyModel
    {
        public event Action UpdatePosition = delegate {  };
        public event Action ChangeHealth = delegate {  };

        public Vector2 Position { get; private set; }
        public int Health { get; private set; }
        public bool IsDead => Health <= 0;
        
        private readonly EnemyConfig _enemyConfig;
        private readonly Vector2 _moveDirection = Vector2.down;
        
        private float _speed;
        
        public EnemyModel(GameSettings gameSettings)
        {
            _enemyConfig = gameSettings.EnemyConfig;

            _speed = Random.Range(_enemyConfig.MinSpeedEnemy, _enemyConfig.MaxSpeedEnemy);
            
            Health = gameSettings.EnemyConfig.Health;
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
            UpdatePosition?.Invoke();
        }

        public void Move()
        {
            Position += _moveDirection * _speed * Time.deltaTime;
            UpdatePosition?.Invoke();
        }

        public void Damage(int damage)
        {
            Health -= damage;
            ChangeHealth?.Invoke();
        }
    }
}
