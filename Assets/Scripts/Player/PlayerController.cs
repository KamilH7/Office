using GameManagement;
using InputSystem.Events;
using Player.Shooting;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Serialized Fields
        
        [SerializeField]
        private GunController gunController;
        
        [Header("Listening To:"), SerializeField]
        private FingerDown fingerDown;

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

        #endregion

        #region Private Methods

        private void InputDetected()
        {
            if (GameLoop.isGameRunning)
            {
               gunController.Shoot();
            }
        }

        private void AssignEvents()
        {
            fingerDown.Subscribe(InputDetected);
        }

        private void UnAssignEvents()
        {
            fingerDown.UnSubscribe(InputDetected);
        }

        #endregion
    }
}