using System.Collections.Generic;
using System.Linq;
using GameCamera;
using Helpers;
using UnityEngine;
using Random = System.Random;

namespace SlotSystem
{
    public class SlotManager : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private GameCameraData gameCameraData;
        [SerializeField]
        private List<SpawnSlot> spawnSlots;
        [SerializeField]
        private float viewportOffset;

        #endregion

        #region Public Methods

        public SpawnSlot TryGetRandomAvailableSpawnSlot()
        {
            List<SpawnSlot> availableSlots = spawnSlots.Where(slot => !slot.IsOccupied && !IsInCameraViewport(slot.transform.position)).ToList();

            Random random = new Random();

            SpawnSlot assignedSlot = availableSlots.Count > 0 ? availableSlots[random.Next(0, availableSlots.Count - 1)] : null;

            return assignedSlot;
        }

        public void ClearAllSlots()
        {
            foreach (SpawnSlot spawnSlot in spawnSlots)
            {
                spawnSlot.ClearSpot();
            }
        }

        #endregion

        #region Private Methods

        private bool IsInCameraViewport(Vector3 point)
        {
            Camera cameraReference = gameCameraData.CameraReference;

            Vector3 viewPortPoint = cameraReference.WorldToViewportPoint(point);

            return viewPortPoint.x.IsInRange(0 + viewportOffset, 1 - viewportOffset) && 
                   viewPortPoint.y.IsInRange(0 + viewportOffset, 1 - viewportOffset) && 
                   viewPortPoint.z > 0;
        }

        #endregion
    }
}