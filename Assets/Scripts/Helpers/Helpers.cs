using UnityEngine;

namespace Helpers
{
    public static class Helpers
    {
        #region Private Fields

        private static readonly string EnemyTag = "Enemy";

        #endregion

        #region Public Methods

        public static bool IsEnemy(this Component component) => component.CompareTag(EnemyTag);

        #endregion
    }
}