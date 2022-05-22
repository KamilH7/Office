using Game.Events;
using GameManagement;
using PowerUpSystem.PowerUps;
using SlotSystem;
using UnityEngine;
using Random = System.Random;

namespace PowerUpSystem.Spawning
{
    public class PowerUpSpawner : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private int spawnTimerMin;
        [SerializeField]
        private int spawnTimerMax;
        [SerializeField]
        private SlotManager slotManager;
        [SerializeField]
        private PowerUpSpawnTable powerUpSpawnTable;

        [SerializeField, Header("Listening To")]
        private GameEnded gameEnded;

        #endregion

        #region Private Fields

        private float timer;
        private float randomTimer;
        private Random random;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            AssignCallbacks();
            random = new Random();
        }

        private void OnDisable()
        {
            UnAssignCallbacks();
        }

        private void Start()
        {
            ResetValues();
        }

        private void Update()
        {
            if (GameLoop.isGameRunning)
            {
                timer += Time.deltaTime;

                if (timer >= randomTimer)
                {
                    TrySpawnPowerUp();
                    timer = 0;
                    randomTimer = random.Next(spawnTimerMin, spawnTimerMax);
                }
            }
        }

        #endregion

        #region Private Methods

        private void ResetValues()
        {
            timer = 0;
            randomTimer = random.Next(spawnTimerMin, spawnTimerMax);
            slotManager.ClearAllSlots();
        }

        private void TrySpawnPowerUp()
        {
            SpawnSlot spawnSlot = slotManager.TryGetRandomAvailableSpawnSlot();

            if (spawnSlot)
            {
                BasePowerUpController powerUp = Instantiate(powerUpSpawnTable.GetRandomPowerUpPrefab());
                spawnSlot.Assign(powerUp);
            }
        }

        private void AssignCallbacks()
        {
            gameEnded.Subscribe(ResetValues);
        }

        private void UnAssignCallbacks()
        {
            gameEnded.UnSubscribe(ResetValues);
        }

        #endregion
    }
}