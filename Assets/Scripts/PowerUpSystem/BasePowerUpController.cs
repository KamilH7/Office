using System;
using Player.Shooting;
using SlotSystem;
using UnityEngine;

namespace PowerUpSystem.PowerUps
{
    public abstract class BasePowerUpController : MonoBehaviour, IShootable, ISlottable
    {
        #region Serialized Fields

        [SerializeField]
        protected Transform powerUpTransform;

        #endregion

        #region Public Properties

        public Action ExitSlot { get; set; }

        #endregion

        #region Public Methods

        public virtual void HitByBullet(float damage)
        {
        }

        public virtual void AssignSlot(Transform slotTransform)
        {
            powerUpTransform.parent = slotTransform;
            powerUpTransform.forward = slotTransform.forward;
            powerUpTransform.rotation = slotTransform.rotation;
            powerUpTransform.localPosition = Vector3.zero;
        }

        #endregion
    }
}