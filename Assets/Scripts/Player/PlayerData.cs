using Player.Events;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "SO/Player/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        #region Serialized Fields

        [SerializeField, Header("Settings")]
        private int maxHealth;

        [SerializeField, Header("Broadcasting On")]
        private PlayerDamaged playerDamaged;
        [SerializeField]
        private PlayerHealed playerHealed;
        [SerializeField]
        private PlayerDied playerDied;

        #endregion

        #region Private Fields

        private int currentHealth;

        #endregion

        #region Unity Callbacks

        private void OnValidate()
        {
            currentHealth = maxHealth;
        }

        #endregion

        #region Public Methods

        public void ChangeHealth(int changeAmount)
        {
            currentHealth += changeAmount;
            Mathf.Clamp(currentHealth, 0, maxHealth);

            if (changeAmount > 0)
            {
                playerDamaged.Invoke(changeAmount);

                if (currentHealth == 0)
                {
                    playerDied.Invoke();
                }
            }
            else if (changeAmount < 0)
            {
                playerHealed.Invoke(changeAmount);
            }
        }

        public float GetHealthPercentage()
        {
            return (float) currentHealth / maxHealth;
        }

        #endregion
    }
}