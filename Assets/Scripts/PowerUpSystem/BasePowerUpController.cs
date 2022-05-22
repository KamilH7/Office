using System;
using Player.Shooting;
using SlotSystem;
using UnityEngine;

namespace PowerUpSystem.PowerUps
{
    public abstract class BasePowerUpController : MonoBehaviour, IShootable, ISlottable
    {
        [SerializeField]
        private Transform powerUpTransform;
        
        public virtual void HitByBullet(float damage)
        {
        }

        public Action ExitSlot { get; set; }
        public virtual void AssignSlot(Transform slotTransform)
        {
            powerUpTransform.parent = slotTransform;
            powerUpTransform.forward = slotTransform.forward;
            powerUpTransform.rotation = slotTransform.rotation;
            powerUpTransform.localPosition = Vector3.zero;
        }
    }
}
