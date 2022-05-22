using InputSystem.Events;
using UnityEngine;

namespace InputSystem
{
    public class InputController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField, Header("Broadcasting On")]
        private FingerUp fingerUp;
        [SerializeField]
        private FingerDown fingerDown;

        private bool fingerDownInvoked;

        private void Update()
        {
            if (IsTouching && !fingerDownInvoked)
            {
                fingerDown.Invoke();
                fingerDownInvoked = true;
            }
            else if (!IsTouching && fingerDownInvoked)
            {
                fingerUp.Invoke();
                fingerDownInvoked = false;
            }
        }

#if UNITY_EDITOR
        private bool IsTouching => Input.GetMouseButtonDown(0);
#else
        private bool IsTouching => Input.touchCount > 0;
#endif

        #endregion
    }
}