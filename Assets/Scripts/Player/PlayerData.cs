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
        [SerializeField]
        private int baseDamage;

        [SerializeField, Header("Broadcasting On")]
        private PlayerDamaged playerDamaged;
        [SerializeField]
        private PlayerHealed playerHealed;
        [SerializeField]
        private PlayerDied playerDied;

        #endregion

        #region Public Properties

        public int CurrentHealth { get; private set; }
        public int CurrentScore { get; private set; }
        public int CurrentDamage { get; private set; }

        #endregion

        #region Public Methods

        public void RestartPlayerValues()
        {
            CurrentScore = 0;
            CurrentHealth = maxHealth;
            CurrentDamage = baseDamage;
        }

        public void ChangeHealth(int changeAmount)
        {
            CurrentHealth += changeAmount;

            Mathf.Clamp(CurrentHealth, 0, maxHealth);

            if (changeAmount > 0)
            {
                playerDamaged.Invoke(changeAmount);

                if (CurrentHealth == 0)
                {
                    playerDied.Invoke(CurrentScore);
                }
            }
            else if (changeAmount < 0)
            {
                playerHealed.Invoke(changeAmount);
            }
        }

        public void AddScore(int amount)
        {
            CurrentScore += amount;
        }

        public float GetHealthPercentage()
        {
            return (float) CurrentHealth / maxHealth;
        }

        #endregion
    }
}