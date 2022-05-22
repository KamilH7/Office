using System;

namespace EnemySystem.Spawning
{
    [Serializable]
    public class SpawnableEnemy
    {
        public BaseEnemyController prefab;
        public int spawnWeight;
    }
}