using System;
using UnityEngine;

namespace GameEventSystem
{
    public abstract class GameEvent : ScriptableObject
    {
        #region Events

        private event Action OnInvoke;

        #endregion

        #region Public Methods

        public void Subscribe(Action action) 
        {
            OnInvoke += action;
        }

        public void UnSubscribe(Action action)
        {
            OnInvoke -= action;
        }

        public virtual void Invoke()
        {
            OnInvoke?.Invoke();
        }

        #endregion
    }
}