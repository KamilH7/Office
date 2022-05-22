using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EnemySystem.Spawning
{
    [CreateAssetMenu(fileName = "EnemySpawnTable", menuName = "SO/EnemySystem/EnemySpawnTable")]
    public class EnemySpawnTable : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField]
        private List<SpawnableEnemy> spawnableEnemies;

        #endregion

        #region Public Methods

        public BaseEnemyController GetRandomEnemyPrefab()
        {
            int randomNumber = Random.Range(0, CalculateWeightSum());

            foreach (SpawnableEnemy enemy in spawnableEnemies)
            {
                if (enemy.spawnWeight >= randomNumber)
                {
                    return enemy.prefab;
                }

                randomNumber -= enemy.spawnWeight;
            }

            return null;
        }

        #endregion

        #region Private Methods

        private int CalculateWeightSum()
        {
            return spawnableEnemies.Sum(enemy => enemy.spawnWeight);
        }

        #endregion
    }
}