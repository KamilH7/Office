﻿using Game.Events;
using GameManagement;
using SlotSystem;
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
        private EnemySpawnTable enemySpawnTable;

        [SerializeField, Header("Listening To")]
        private RequestNewSlot requestNewSlot;
        [SerializeField]
        private GameEnded gameEnded;

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
            ResetValues();
        }

        private void Update()
        {
            if (GameLoop.isGameRunning)
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
        }

        #endregion

        #region Private Methods

        private void ResetValues()
        {
            timer = 0;
            currentDifficulty = 1;
            currentSpawnTimer = baseSpawnTimer;
            slotManager.ClearAllSlots();
        }

        private void TrySpawnEnemy()
        {
            SpawnSlot spawnSlot = slotManager.TryGetRandomAvailableSpawnSlot();

            if (spawnSlot)
            {
                BaseEnemyController enemy = Instantiate(enemySpawnTable.GetRandomEnemyPrefab());
                spawnSlot.Assign(enemy);
                enemy.Initialize(currentDifficulty);
            }
        }

        private void RepositionEnemy(ISlottable invokerEnemy)
        {
            SpawnSlot spawnSlot = slotManager.TryGetRandomAvailableSpawnSlot();

            if (spawnSlot)
            {
                invokerEnemy.ExitSlot.Invoke();
                spawnSlot.Assign(invokerEnemy);
            }
        }

        private void AssignCallbacks()
        {
            requestNewSlot.Subscribe(RepositionEnemy);
            gameEnded.Subscribe(ResetValues);
        }

        private void UnAssignCallbacks()
        {
            requestNewSlot.UnSubscribe(RepositionEnemy);
            gameEnded.UnSubscribe(ResetValues);
        }

        #endregion
    }
}