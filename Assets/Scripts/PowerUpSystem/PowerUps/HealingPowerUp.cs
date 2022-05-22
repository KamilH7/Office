using Player;
using UnityEngine;

namespace PowerUpSystem.PowerUps
{
    public class HealingPowerUp : BasePowerUpController
    {
        #region Serialized Fields

        [SerializeField]
        private int healAmount;
        [SerializeField]
        private PlayerData playerData;

        #endregion

        #region Public Methods

        public override void HitByBullet(float damage)
        {
            playerData.ChangeHealth(healAmount);
            ExitSlot.Invoke();
            Destroy(gameObject);
        }

        #endregion
    }
}