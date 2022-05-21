using UnityEngine;

namespace EnemySystem.Spawning
{
    [System.Serializable]
    public class SpawnableEnemy
    {
        public BaseEnemyController prefab;
        public int spawnWeight;
    }
}