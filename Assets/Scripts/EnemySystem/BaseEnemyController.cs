using System;
using Player;
using Player.Shooting;
using SlotSystem;
using UnityEngine;

namespace EnemySystem
{
    public abstract class BaseEnemyController : MonoBehaviour, IShootable, ISlottable
    {
        #region Serialized Fields

        [Header("Base Settings"), SerializeField]
        protected float baseDamageTimer;
        [SerializeField]
        protected int baseDamage;
        [SerializeField]
        protected int scoreForShooting;
        [SerializeField]
        protected Transform enemyTransform;
        [SerializeField]
        protected PlayerData playerData;

        #endregion

        #region Private Fields

        private float currentDamageTimer;

        #endregion

        #region Public Properties

        public Action ExitSlot { get; set; }

        #endregion

        #region Unity Callbacks

        protected virtual void Update()
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

        public virtual void Initialize(float difficulty)
        {
        }

        public void AssignSlot(Transform newTransform)
        {
            enemyTransform.parent = newTransform;
            enemyTransform.forward = newTransform.forward;
            enemyTransform.rotation = newTransform.rotation;
            enemyTransform.localPosition = Vector3.zero;
        }

        public virtual void HitByBullet(float damage)
        {
            playerData.AddScore(scoreForShooting);
            ExitSlot.Invoke();
            Destroy(gameObject);
        }

        #endregion
    }
}