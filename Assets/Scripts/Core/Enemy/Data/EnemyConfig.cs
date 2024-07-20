using System;
using Core.Enemy.View;
using UnityEngine;

namespace Core.Enemy.Data
{
    [Serializable]
    public class EnemyConfig
    {
        [field:SerializeField] public EnemyView EnemyPrefab { get; private set; }
        
        //to do desirable to add Min/Max validation or custom MinMaxAttribute
        [Tooltip("Min time between spawn enemy")]
        [field:SerializeField, Range(0, 100)] public float MinSpawnTime { get; private set; }
        [Tooltip("Max time between spawn enemy")]
        [field:SerializeField, Range(0, 100)] public float MaxSpawnTime { get; private set; }
        
        //to do desirable to add Min/Max validation or custom MinMaxAttribute
        [Tooltip("Min speed of enemy")]
        [field:SerializeField, Range(0, 10f)] public float MinSpeedEnemy { get; private set; } = 0.05f;

        [Tooltip("Max speed of enemy")]
        [field: SerializeField, Range(0, 10f)] public float MaxSpeedEnemy { get; private set; } = 0.2f;

        [Tooltip("Health of enemy")]
        [field: SerializeField] public int Health { get; private set; } = 3;

        [Tooltip("Damage of enemy")]
        [field: SerializeField] public int Damage { get; private set; } = 1;
        
        [Tooltip("Body size")]
        [field: SerializeField] public float EnemyRadius { get; private set; } = 0.3f;
    }
}
