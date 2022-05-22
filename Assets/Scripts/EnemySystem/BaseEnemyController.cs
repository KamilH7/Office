using System;
using Player;
using UnityEngine;

namespace EnemySystem
{
    public abstract class BaseEnemyController : MonoBehaviour
    {
        #region Events

        public event Action OnReleasedFromCurrentSpot;

        #endregion

        #region Serialized Fields

        [Header("Base Settings"), SerializeField]
        protected float baseDamageTimer;
        [SerializeField]
        protected int baseDamage;
        [SerializeField]
        protected Transform enemyTransform;
        [SerializeField]
        protected PlayerData playerData;

        #endregion

        #region Private Fields

        private float currentDamageTimer;

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

        public virtual void HitByPlayer(float damage)
        {
            FreeCurrentSlot();
            Destroy(gameObject);
        }

        public virtual void Initialize(float difficulty)
        {
        }

        public void FreeCurrentSlot()
        {
            OnReleasedFromCurrentSpot?.Invoke();
        }

        public void PositionEnemy(Transform newTransform)
        {
            enemyTransform.parent = newTransform;
            enemyTransform.forward = newTransform.forward;
            enemyTransform.rotation = newTransform.rotation;

            enemyTransform.localPosition = Vector3.zero;
        }

        #endregion
    }
}