using System;
using System.Collections;
using Game.Events;
using GameManagement.Events;
using InputSystem.Events;
using Player;
using Player.Events;
using UnityEngine;

namespace GameManagement
{
    public class GameLoop : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private PlayerData playerData;
        [SerializeField]
        private float inputDelay;

        [Header("Listening To"), SerializeField]
        private PlayerDied playerDied;
        [SerializeField]
        private FingerDown fingerUp;

        [Header("Broadcasting On"), SerializeField]
        private GameStarted gameStarted;
        [SerializeField]
        private GameToStartScreen gameToStartScreen;
        [SerializeField]
        private GameEnded gameEnded;

        #endregion

        #region Constants

        public static bool isGameRunning;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            AssignEvents();
        }

        private void OnDisable()
        {
            UnAssignEvents();
        }

        private void Start()
        {
            SetupPreGame();
        }

        #endregion

        #region Private Methods

        private void SetupPreGame()
        {
            fingerUp.UnSubscribe(SetupPreGame);
            StartCoroutine(EnableInputAfterDelay(SetupInGame));
            playerData.RestartPlayerValues();
            gameToStartScreen.Invoke();
        }

        private void SetupInGame()
        {
            fingerUp.UnSubscribe(SetupInGame);
            isGameRunning = true;
            playerData.RestartPlayerValues();
            gameStarted.Invoke();
        }

        private void SetupPostGame()
        {
            isGameRunning = false;
            gameEnded.Invoke();
            StartCoroutine(EnableInputAfterDelay(SetupPreGame));
        }

        private void AssignEvents()
        {
            playerDied.Subscribe(SetupPostGame);
        }

        private void UnAssignEvents()
        {
            playerDied.UnSubscribe(SetupPostGame);
        }

        private IEnumerator EnableInputAfterDelay(Action onInput)
        {
            yield return new WaitForSeconds(inputDelay);
            fingerUp.Subscribe(onInput);
        }

        #endregion
    }
}