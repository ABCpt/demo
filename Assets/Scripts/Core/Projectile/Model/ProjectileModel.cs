using System;
using Core.Data;
using Core.Projectile.Data;
using UnityEngine;

namespace Core.Projectile.Model
{
    public class ProjectileModel
    {
        public event Action UpdatePosition = delegate {  };
        public Vector2 Position { get; private set; }
        
        private readonly ProjectileConfig _projectileConfig;

        private Vector2 _moveDirection;

        public ProjectileModel(GameSettings gameSettings)
        {
            _projectileConfig = gameSettings.ProjectileConfig;
        }

        public ProjectileModel SetPosition(Vector2 position)
        {
            Position = position;
            UpdatePosition?.Invoke();
            return this;
        }
        
        public ProjectileModel SetDirection(Vector2 direction)
        {
            _moveDirection = direction;
            return this;
        }

        public void Move()
        {
            Position += _moveDirection * _projectileConfig.ProjectileSpeed * Time.deltaTime;
            UpdatePosition?.Invoke();
        }
    }
}
