using System;
using UnityEngine;

namespace Core.Level.Data
{
    [Serializable]
    public class LevelConfig
    {
        //to do desirable to add Min/Max validation or custom MinMaxAttribute
        [Tooltip("Min number of enemies for win")]
        [field:SerializeField, Range(0, 100)] public int MinEnemies { get; private set; }
        [Tooltip("Max number of enemies for win")]
        [field:SerializeField, Range(0, 100)] public int MaxEnemies { get; private set; }
        
        [field:SerializeField] public int CameraSize { get; private set; }
        
        [Tooltip("Player's area")]
        [field:SerializeField] public int MoveAreaHeight { get; private set; }
    }
}
