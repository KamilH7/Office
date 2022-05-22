using EnemySystem.Slots;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace EnemySystem.Enemies
{
    public class BossEnemy : BaseEnemyController
    {
        #region Serialized Fields

        [Header("Boss Enemy Settings")]
        [SerializeField]
        private float maxHealth = 40;
        [SerializeField]
        private Image healthBarFillImage;
        [SerializeField]
        private RequestNewSlot requestNewSlot;
        
        private float currentHealth;
        #endregion

        #region Public Methods

        private void Start()
        {
            currentHealth = maxHealth;
            UpdateHealthBar();
        }

        public override void HitByPlayer(float damage)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            UpdateHealthBar();
            
            if (currentHealth == 0)
            {
                FreeCurrentSlot();
                Destroy(gameObject);
            }
            else
            {
                TryTeleporting();
            }
        }

        private void UpdateHealthBar()
        {
            healthBarFillImage.fillAmount = currentHealth / maxHealth;
        }
        private void TryTeleporting()
        {
            requestNewSlot.Invoke(this);
        }

        #endregion
    }
}