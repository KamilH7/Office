using UnityEngine;

namespace GameCamera
{
    public class CameraTracker : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private GameCameraData gameCameraData;
        [SerializeField]
        private Camera gameCamera;
        [SerializeField]
        private Transform gameCameraTransform;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            gameCameraData.SetCameraReference(gameCamera);
        }

        private void Update()
        {
            gameCameraData.UpdateCameraPointingDirection(gameCameraTransform.forward);
        }

        #endregion
    }
}