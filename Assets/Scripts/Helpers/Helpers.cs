using UnityEngine;

namespace Helpers
{
    public static class Helpers
    {
        #region Private Fields

        private static readonly string ShootableTag = "Shootable";

        #endregion

        #region Public Methods

        public static bool IsShootable(this Component component) => component.CompareTag(ShootableTag);
        public static bool IsInRange(this float value, float min, float max) => value >= min && value <= max;

        #endregion
    }
}