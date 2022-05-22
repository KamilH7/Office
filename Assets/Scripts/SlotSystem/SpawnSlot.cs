using UnityEngine;

namespace SlotSystem
{
    public class SpawnSlot : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private Light spotlight;
        [SerializeField]
        private Transform slotTransform;

        #endregion

        #region Public Properties

        public bool IsOccupied { get; private set; }

        #endregion

        #region Public Methods

        public void Assign(ISlottable slottable)
        {
            if (!IsOccupied)
            {
                spotlight.enabled = true;
                slottable.ExitSlot += UnAssignEnemy;
                slottable.AssignSlot(slotTransform);
                IsOccupied = true;
            }
            else
            {
                Debug.LogError("Spot is occupied by another object");
            }
        }

        public void ClearSpot()
        {
            spotlight.enabled = false;
            DestroyAllChildren();
        }

        #endregion

        #region Private Methods

        private void UnAssignEnemy()
        {
            spotlight.enabled = false;
            IsOccupied = false;
        }

        private void DestroyAllChildren()
        {
            foreach (Transform t in slotTransform)
            {
                Destroy(t.gameObject);
            }
        }

        #endregion
    }
}