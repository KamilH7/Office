using UnityEngine;

namespace Helpers
{
    public static class Helpers
    {
        private static readonly string EnemyTag = "Enemy";
    
        public static bool IsEnemy(this Component component) => component.CompareTag(EnemyTag);
    }
}