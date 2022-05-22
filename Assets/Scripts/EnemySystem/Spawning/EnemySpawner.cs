using EnemySystem.Slots;
using UnityEngine;

namespace EnemySystem.Spawning
{
    public class EnemySpawner : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private float baseSpawnTimer = 5;
        [SerializeField]
        private float difficultyIncreaseRate = 0.001f;
        [SerializeField]
        private SlotManager slotManager;
        [SerializeField]
        private SpawnTable spawnTable;

        [SerializeField, Header("Listening To")]
        private RequestNewSlot requestNewSlot;

        #endregion

        #region Private Fields

        private float currentDifficulty = 1;
        private float currentSpawnTimer;

        private float timer;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            AssignCallbacks();
        }

        private void OnDisable()
        {
            UnAssignCallbacks();
        }

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

        private void RepositionEnemy(BaseEnemyController invokerEnemy)
        {
            SpawnSlot spawnSlot = slotManager.TryGetRandomFreeSpawnSlot();

            if (spawnSlot)
            {
                invokerEnemy.FreeCurrentSlot();
                spawnSlot.AssignEnemy(invokerEnemy);
            }
        }

        private void AssignCallbacks()
        {
            requestNewSlot.Subscribe(RepositionEnemy);
        }

        private void UnAssignCallbacks()
        {
            requestNewSlot.UnSubscribe(RepositionEnemy);
        }

        #endregion
    }
}