using Game.Events;
using InputSystem.Events;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private PlayerData playerData;

        [Header("Listening To:"), SerializeField]
        private FingerDown fingerDown;
        [SerializeField]
        private GameStarted gameStarted;

        #endregion

        #region Private Fields

        private float damageTimer = 5;
        private float currentTimer;

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

        private void Update()
        {
            currentTimer += Time.deltaTime;

            if (currentTimer >= damageTimer)
            {
                Damage();
                currentTimer = 0;
            }
        }

        #endregion

        #region Private Methods

        private void InitializePlayerData()
        {
            playerData.Initialize();
        }

        private void Damage()
        {
            playerData.ChangeHealth(-5);
        }

        private void AssignEvents()
        {
            fingerDown.Subscribe(Damage);
            gameStarted.Subscribe(InitializePlayerData);
        }

        private void UnAssignEvents()
        {
            fingerDown.UnSubscribe(Damage);
            gameStarted.Subscribe(InitializePlayerData);
        }

        #endregion
    }
}