using UnityEngine;

namespace GameCamera
{
    [CreateAssetMenu(fileName = "CameraData", menuName = "SO/Camera/CameraData")]
    public class GameCameraData : ScriptableObject
    {
        #region Public Properties

        public Vector3 CameraPointingDirection { get; private set; }

        #endregion

        #region Public Methods

        public void UpdateCameraPointingDirection(Vector3 newPointingDirection)
        {
            CameraPointingDirection = newPointingDirection;
        }

        #endregion
    }
}