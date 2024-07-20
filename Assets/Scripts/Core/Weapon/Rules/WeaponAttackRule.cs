using System;
using Core.Data;
using Core.Enemy.Services;
using Core.Level.Interface;
using Core.Player.Model;
using Core.Weapon.Data;
using Core.Weapon.Model;
using UnityEngine;

namespace Core.Weapon.Rules
{
    public class WeaponAttackRule : ILevelUpdatable
    {
        private readonly WeaponModel _weaponModel;
        private readonly PlayerModel _playerModel;
        private readonly EnemiesService _enemiesService;
        private readonly WeaponConfig _weaponConfig;
        
        private IDisposable _updateStream;

        public WeaponAttackRule(WeaponModel weaponModel, PlayerModel playerModel, EnemiesService enemiesService, GameSettings gameSettings)
        {
            _weaponModel = weaponModel;
            _playerModel = playerModel;
            _enemiesService = enemiesService;
            _weaponConfig = gameSettings.WeaponConfig;
        }

        public void UpdateLevel()
        {
            if (_weaponModel.IsWeaponReady())
                    WeaponAttack();
        }

        private void WeaponAttack()
        {
            var nearEnemy = _enemiesService.GetNearEnemyByPosition(_playerModel.Position);

            if(nearEnemy == null)
                return;

            if (Vector2.Distance(_playerModel.Position, nearEnemy.Position) > _weaponConfig.RadiusAttack)
                return;
            
            _weaponModel.WeaponAttack(nearEnemy.Position);
        }
    }
}
