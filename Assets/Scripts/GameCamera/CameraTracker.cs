using UnityEngine;

namespace GameCamera
{
    public class CameraTracker : MonoBehaviour
    {
        [SerializeField]
        private GameCameraData gameCameraData;
        [SerializeField]
        private Transform gameCameraTransform;
        private void Update()
        {
            gameCameraData.UpdateCameraPointingDirection(gameCameraTransform.forward);
        }
    }
}
