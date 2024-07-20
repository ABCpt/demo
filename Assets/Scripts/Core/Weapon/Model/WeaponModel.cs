using System;
using Core.Data;
using Core.Weapon.Data;
using UnityEngine;

namespace Core.Weapon.Model
{
    public class WeaponModel
    {
        private readonly WeaponConfig _weaponConfig;
        private float _attackTime;

        public event Action<Vector2> Attack = delegate { };

        public WeaponModel(GameSettings gameSettings)
        {
            _weaponConfig = gameSettings.WeaponConfig;
        }

        public bool IsWeaponReady()
        {
            return Time.time >= _attackTime + _weaponConfig.AttackRate;
        }

        public void WeaponAttack(Vector2 targetPosition)
        {
            _attackTime = Time.time;
            Attack?.Invoke(targetPosition);
        }
    }
}
