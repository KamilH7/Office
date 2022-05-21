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
        private int currentScore;

        #endregion

        #region Public Methods

        public void Initialize()
        {
            currentHealth = maxHealth;
            currentScore = 0;
        }

        public void ChangeHealth(int changeAmount)
        {
            currentHealth += changeAmount;
            Mathf.Clamp(currentHealth, 0, maxHealth);

            if (changeAmount > 0)
            {
                playerDamaged.Invoke(changeAmount);

                if (currentHealth == 0)
                {
                    playerDied.Invoke(currentScore);
                }
            }
            else if (changeAmount < 0)
            {
                playerHealed.Invoke(changeAmount);
            }
        }

        public void AddScore(int amount)
        {
        }

        public float GetHealthPercentage()
        {
            return (float) currentHealth / maxHealth;
        }

        #endregion
    }
}