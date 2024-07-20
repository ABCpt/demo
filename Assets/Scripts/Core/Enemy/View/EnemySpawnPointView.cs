using Core.Enemy.Services;
using UnityEngine;
using Zenject;

namespace Core.Enemy.View
{
    public class EnemySpawnPointView : MonoBehaviour
    {
        [Inject]
        public void Construct(EnemiesService enemiesService)
        {
            enemiesService.AddSpawnPoint(this.transform.position);
            gameObject.SetActive(false);
        }
    }
}
