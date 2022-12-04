using System.Collections;
using UnityEngine;

namespace Player.Shooting
{
    public class GunController : MonoBehaviour
    {
        [SerializeField]
        private BulletController bulletPrefab;
        [SerializeField]
        private Transform bulletOrigin;
        [SerializeField]
        private Animator gunAnimator;
        [SerializeField]
        private AnimationClip recoilAnimation;
        [SerializeField]
        private string shootTriggerName;

        private bool canShoot = true;

        public void Shoot()
        {
            if (canShoot == true)
            {
                InitializeBullet();
                ApplyRecoil();
                StartShootCooldown();
            }
        }

        private void InitializeBullet()
        {
            BulletController bullet = Instantiate(bulletPrefab);
            bullet.Initialize(bulletOrigin.position, bulletOrigin.forward);
        }
        
        private void ApplyRecoil()
        {
            StartRecoilAnimation();
        }

        private void StartRecoilAnimation()
        {
            gunAnimator.SetTrigger(shootTriggerName);
        }

        private void StartShootCooldown()
        {
            StartCoroutine(ShootCooldownCoroutine());
        }

        private IEnumerator ShootCooldownCoroutine()
        {
            canShoot = false;
            yield return new WaitForSeconds(recoilAnimation.length);
            canShoot = true;
        }
    }
}