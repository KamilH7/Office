using System;
using UnityEngine;

namespace GameEventSystem
{
    public abstract class GameEventWithParameter<T> : ScriptableObject
    {
        #region Events

        private event Action<T> OnInvoke;

        #endregion

        #region Public Methods
        
        
        public void Subscribe(Action<T> action)
        {
            OnInvoke += action;
        }
        
        public void UnSubscribe(Action<T> action)
        {
            OnInvoke -= action;
        }
        
        public virtual void Invoke(T parameter)
        {
            OnInvoke?.Invoke(parameter);
        }

        #endregion
    }
}