using System;
using Core.Data;
using Core.Level.Data;
using Core.Level.Interface;
using Core.Player.Data;
using UnityEngine;

namespace Core.Player.Model
{
    public class PlayerModel : ILevelStartable
    {
        public event Action UpdatePosition = delegate {  };
        public event Action UpdateHealth = delegate {  };
        public Vector2 Position { get; private set; }
        public int Health { get; private set; }
        public bool IsDead => Health <= 0;
        
        private readonly PlayerConfig _playerConfig;
        private readonly LevelConfig _levelConfig;

        public PlayerModel(GameSettings gameSettings)
        {
            _playerConfig = gameSettings.PlayerConfig;
            _levelConfig = gameSettings.LevelConfig;
        }

        public void Move(Vector2 direction)
        {
            var position = Position + direction * _playerConfig.Speed * Time.deltaTime;
            Position = ClampPosition(position);
            UpdatePosition?.Invoke();
        }

        private Vector2 ClampPosition(Vector2 position)
        {
            var correctPosition = Vector2.zero;

            var currentAspectRatio = Screen.width / (float)Screen.height;

            correctPosition.x = Mathf.Clamp(position.x, 
                -_levelConfig.CameraSize * currentAspectRatio + _playerConfig.PlayerSize.x / 2, 
                _levelConfig.CameraSize * currentAspectRatio - _playerConfig.PlayerSize.x / 2);
            
            correctPosition.y = Mathf.Clamp(position.y, 
                -_levelConfig.CameraSize + _playerConfig.PlayerSize.y / 2, 
                -_levelConfig.CameraSize - _playerConfig.PlayerSize.y / 2 + _levelConfig.MoveAreaHeight);
            
            return correctPosition;
        }
        
        public void Damage(int damage)
        {
            Health -= damage;

            Health = Health < 0 ? 0 : Health;
            
            UpdateHealth?.Invoke();
        }

        public void StartLevel()
        {
            Position = _playerConfig.StartPosition;
            Health = _playerConfig.Health;
            
            UpdatePosition?.Invoke();
            UpdateHealth?.Invoke();
        }
    }
}
