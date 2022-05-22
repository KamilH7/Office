using Game.Events;
using GameManagement.Events;
using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField, Header("UI References")]
        private RectTransform inGameUI;
        [SerializeField]
        private RectTransform preGameUI;
        [SerializeField]
        private RectTransform postGameUI;

        [SerializeField, Header("Listening To")]
        private GameStarted gameStarted;
        [SerializeField]
        private GameEnded gameEnded;
        [SerializeField]
        private GameToStartScreen gameToStartScreen;

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

        #endregion

        #region Private Methods

        private void EnablePreGameUI()
        {
            preGameUI.gameObject.SetActive(true);
            inGameUI.gameObject.SetActive(false);
            postGameUI.gameObject.SetActive(false);
        }

        private void EnableInGameUI()
        {
            preGameUI.gameObject.SetActive(false);
            inGameUI.gameObject.SetActive(true);
            postGameUI.gameObject.SetActive(false);
        }

        private void EnablePostGameUI()
        {
            preGameUI.gameObject.SetActive(false);
            inGameUI.gameObject.SetActive(false);
            postGameUI.gameObject.SetActive(true);
        }

        private void AssignCallbacks()
        {
            gameToStartScreen.Subscribe(EnablePreGameUI);
            gameStarted.Subscribe(EnableInGameUI);
            gameEnded.Subscribe(EnablePostGameUI);
        }

        private void UnAssignCallbacks()
        {
            gameToStartScreen.UnSubscribe(EnablePreGameUI);
            gameStarted.UnSubscribe(EnableInGameUI);
            gameEnded.UnSubscribe(EnablePostGameUI);
        }

        #endregion
    }
}