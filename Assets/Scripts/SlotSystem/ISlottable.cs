using System;
using UnityEngine;

namespace SlotSystem
{
    public interface ISlottable
    {
        #region Public Properties

        Action ExitSlot { get; set; }

        #endregion

        #region Public Methods

        void AssignSlot(Transform slotTransform);

        #endregion
    }
}