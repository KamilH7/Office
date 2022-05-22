using EnemySystem;
using Helpers;
using UnityEngine;

namespace Player.Shooting
{
    public class BulletController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private PlayerData playerData;

        [SerializeField, Range(1, 20)]
        private float travelSpeed;
        [SerializeField]
        private float gravityValue;

        #endregion

        #region Private Fields

        private float downwardPull;
        private bool shouldBeTraveling;
        private Transform bulletTransform;

        #endregion

        #region Unity Callbacks
        

        private void Update()
        {
            if (shouldBeTraveling)
            {
                MoveBullet();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            BulletHit();

            if (other.IsEnemy())
            {
                other.GetComponent<BaseEnemyController>().HitByPlayer(playerData.CurrentDamage);
            }
        }

        #endregion

        #region Public Methods

        public void Initialize(Vector3 origin, Vector3 direction)
        {
            bulletTransform = transform;
            
            bulletTransform.position = origin;
            bulletTransform.forward = direction;

            shouldBeTraveling = true;
        }

        #endregion

        #region Private Methods

        private void MoveBullet()
        {
            downwardPull += gravityValue * Time.deltaTime;
            Vector3 moveVector = bulletTransform.forward * (travelSpeed * Time.deltaTime);
            moveVector += Vector3.up * (downwardPull * Time.deltaTime);
            bulletTransform.position += moveVector;
        }

        private void BulletHit()
        {
            Destroy(gameObject);
        }

        #endregion
    }
}