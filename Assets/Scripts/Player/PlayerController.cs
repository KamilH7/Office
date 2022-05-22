using GameCamera;
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
        private BulletController bulletPrefab;
        [SerializeField]
        private GameCameraData gameCameraData;

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

        private void Shoot()
        {
            if (GameLoop.isGameRunning)
            {
                BulletController bullet = Instantiate(bulletPrefab);
                bullet.Initialize(transform.position, gameCameraData.CameraPointingDirection);
            }
        }

        private void AssignEvents()
        {
            fingerDown.Subscribe(Shoot);
        }

        private void UnAssignEvents()
        {
            fingerDown.UnSubscribe(Shoot);
        }

        #endregion
    }
}