using Player;
using UnityEngine;

namespace EnemySystem.Enemies
{
    public class SimpleEnemy : BaseEnemyController
    {
        #region Serialized Fields

        [Header("Settings"), SerializeField]
        private float baseDamageTimer;
        [SerializeField]
        private int baseDamage;

        [Header("References"), SerializeField]
        private PlayerData playerData;

        #endregion

        #region Private Fields

        private float currentDamageTimer;

        #endregion

        #region Unity Callbacks

        private void Update()
        {
            currentDamageTimer += Time.deltaTime;

            if (currentDamageTimer >= baseDamageTimer)
            {
                currentDamageTimer = 0;
                playerData.ChangeHealth(-baseDamage);
            }
        }

        #endregion

        #region Public Methods

        public override void HitByPlayer()
        {
            KillEnemy();
        }

        public override void Initialize(float difficulty)
        {
            baseDamageTimer /= difficulty;
            baseDamage = (int) (baseDamage * difficulty);
        }

        #endregion
    }
}