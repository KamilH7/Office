using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerData playerData;

        private float damageTimer = 5;
        private float currentTimer;
        private void Update()
        {
            currentTimer += Time.deltaTime;

            if (currentTimer >= damageTimer)
            {
                Damage();
                currentTimer = 0;
            }
        }

        private void Damage()
        {
            playerData.ChangeHealth(-5);
        }
    }
}