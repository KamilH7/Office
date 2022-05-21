using System;
using UnityEngine;

namespace EnemySystem
{
    public abstract class BaseEnemyController : MonoBehaviour
    {
        #region Events

        public event Action OnEnemyKilled;

        #endregion

        #region Serialized Fields

        [SerializeField]
        protected Transform enemyTransform;

        #endregion

        #region Public Methods

        public virtual void HitByPlayer()
        {
            KillEnemy();
        }

        public virtual void Initialize(float difficulty)
        {
        }

        public void KillEnemy()
        {
            OnEnemyKilled?.Invoke();
            Destroy(gameObject);
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