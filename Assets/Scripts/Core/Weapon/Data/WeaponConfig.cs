using System;
using UnityEngine;

namespace Core.Weapon.Data
{
    [Serializable]
    public class WeaponConfig
    {
        [Tooltip("Time between player attack.")]
        [field:SerializeField, Range(0, 1)] public float AttackRate { get; private set; } = 0.25f;
        
        [Tooltip("Weapon attack radius")]
        [field:SerializeField, Range(0, 100)] public float RadiusAttack { get; private set; } = 5f;
        
        [Tooltip("Weapon offset")]
        [field:SerializeField] public Vector2 WeaponOffset { get; private set; }
    }
}
