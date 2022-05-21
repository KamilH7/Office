using UnityEngine;

namespace EnemySystem.Slots
{
    public class SpawnSlot : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private Light spotlight;
        [SerializeField]
        private Transform spotEnemyTransform;
        [SerializeField]
        private BaseEnemyController assignedEnemy;

        #endregion

        #region Public Properties

        public bool IsOccupied { get; private set; }

        #endregion

        #region Public Methods

        public void AssignEnemy(BaseEnemyController enemy)
        {
            if (!IsOccupied)
            {
                spotlight.enabled = true;
                enemy.OnEnemyKilled += UnAssignEnemy;
                enemy.PositionEnemy(spotEnemyTransform);
                assignedEnemy = enemy;
                IsOccupied = true;
            }
            else
            {
                Debug.LogError("Spot is occupied by another enemy");
            }
        }

        public void ClearSpot()
        {
            assignedEnemy.KillEnemy();
            spotlight.enabled = false;
        }

        #endregion

        #region Private Methods

        private void UnAssignEnemy()
        {
            assignedEnemy = null;
            IsOccupied = false;
        }

        #endregion
    }
}