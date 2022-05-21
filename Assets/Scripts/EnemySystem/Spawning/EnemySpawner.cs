using EnemySystem.Slots;
using Unity.Collections;
using UnityEngine;

namespace EnemySystem.Spawning
{
    public class EnemySpawner : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private float baseSpawnTimer = 5;
        [SerializeField]
        private float minSpawnTimer = 1;
        [SerializeField]
        private float difficultyIncreaseRate = 0.001f;
        [SerializeField]
        private SlotManager slotManager;
        [SerializeField]
        private SpawnTable spawnTable;
        
        [SerializeField]
        private float currentDifficulty = 1;
        [SerializeField]
        private float currentSpawnTimer;

        #endregion

        #region Private Fields

        private float timer;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            currentSpawnTimer = baseSpawnTimer;
            slotManager.ClearAllSlots();
        }

        private void Update()
        {
            currentDifficulty += currentDifficulty * difficultyIncreaseRate * Time.deltaTime;

            timer += Time.deltaTime;

            if (timer >= currentSpawnTimer)
            {
                TrySpawnEnemy();
                timer = 0;
                currentSpawnTimer = baseSpawnTimer / currentDifficulty;
            }
        }

        #endregion

        #region Private Methods

        private void TrySpawnEnemy()
        {
            SpawnSlot spawnSlot = slotManager.TryGetRandomFreeSpawnSlot();

            if (spawnSlot)
            {
                BaseEnemyController enemy = Instantiate(spawnTable.GetRandomEnemyPrefab());
                spawnSlot.AssignEnemy(enemy);
                enemy.Initialize(currentDifficulty);
            }
        }

        #endregion
    }
}