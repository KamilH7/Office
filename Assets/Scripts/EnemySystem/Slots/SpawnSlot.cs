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
                enemy.OnReleasedFromCurrentSpot += UnAssignEnemy;
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
            spotlight.enabled = false;

            if (assignedEnemy != null)
            {
                assignedEnemy.FreeCurrentSlot();
                Destroy(assignedEnemy.gameObject);
            }
        }

        #endregion

        #region Private Methods

        private void UnAssignEnemy()
        {
            spotlight.enabled = false;
            IsOccupied = false;
        }

        #endregion
    }
}