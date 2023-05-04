using System;
using System.Collections.Generic;
using UnityEngine;
using SH.ScriptableArchitecture.Listeners;

namespace SH.ScriptableArchitecture.Events
{
    public abstract class ScriptableEventType1<T> : ScriptableObject
    {
        private HashSet<ScriptableEventType1Listener<T>> listeners = new();
        private HashSet<Action<T>> actionListeners = new();

        public void Raise(T argument)
        {
            foreach (ScriptableEventType1Listener<T> listener in listeners)
                listener.OnEventRaised(argument);

            foreach (Action<T> actionListener in actionListeners)
                actionListener.Invoke(argument);
        }

        public void AddListener(ScriptableEventType1Listener<T> listener)
        {
            if (!listeners.Add(listener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {listener} already added to {this}.");
        }

        public void AddListener(Action<T> actionListener)
        {
            if (!actionListeners.Add(actionListener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {actionListener} already added to {this}.");
        }

        public void RemoveListener(ScriptableEventType1Listener<T> listener)
        {
            if (!listeners.Remove(listener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {listener} not found in {this}.");
        }

        public void RemoveListener(Action<T> actionListener)
        {
            if (!actionListeners.Remove(actionListener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {actionListener} not found in {this}.");
        }
    }
}