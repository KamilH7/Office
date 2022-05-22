using Player;
using UnityEngine;

namespace PowerUpSystem.PowerUps
{
    public class HealingPowerUp : BasePowerUpController
    {
        #region Serialized Fields

        [SerializeField]
        private float rotationSpeed;
        [SerializeField]
        private int healAmount;
        [SerializeField]
        private PlayerData playerData;

        #endregion

        #region Unity Callbacks

        private void Update()
        {
            Rotate();
        }

        #endregion

        #region Public Methods

        public override void HitByBullet(float damage)
        {
            playerData.ChangeHealth(healAmount);
            ExitSlot.Invoke();
            Destroy(gameObject);
        }

        #endregion

        #region Private Methods

        private void Rotate()
        {
            powerUpTransform.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        }

        #endregion
    }
}