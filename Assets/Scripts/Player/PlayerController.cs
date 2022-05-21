using Game.Events;
using GameCamera;
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
        private PlayerData playerData;
        [SerializeField]
        private GameCameraData gameCameraData;
        
        [Header("Listening To:"), SerializeField]
        private FingerDown fingerDown;
        [SerializeField]
        private GameStarted gameStarted;

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

        private void InitializePlayerData()
        {
            playerData.Initialize();
        }

        private void Shoot()
        {
            BulletController bullet = Instantiate(bulletPrefab);
            bullet.Initialize(transform.position,gameCameraData.CameraPointingDirection);
        }

        private void AssignEvents()
        {
            fingerDown.Subscribe(Shoot);
            gameStarted.Subscribe(InitializePlayerData);
        }

        private void UnAssignEvents()
        {
            fingerDown.UnSubscribe(Shoot);
            gameStarted.Subscribe(InitializePlayerData);
        }

        #endregion
    }
}