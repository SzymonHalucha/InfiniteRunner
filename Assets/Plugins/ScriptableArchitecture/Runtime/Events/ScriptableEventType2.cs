using System;
using System.Collections.Generic;
using UnityEngine;
using SH.ScriptableArchitecture.Listeners;

namespace SH.ScriptableArchitecture.Events
{
    public abstract class ScriptableEventType2<T0, T1> : ScriptableObject
    {
        private HashSet<ScriptableEventType2Listener<T0, T1>> listeners = new();
        private HashSet<Action<T0, T1>> actionListeners = new();

        public void Raise(T0 argument1, T1 argument2)
        {
            foreach (ScriptableEventType2Listener<T0, T1> listener in listeners)
                listener.OnEventRaised(argument1, argument2);

            foreach (Action<T0, T1> actionListener in actionListeners)
                actionListener.Invoke(argument1, argument2);
        }

        public void AddListener(ScriptableEventType2Listener<T0, T1> listener)
        {
            if (!listeners.Add(listener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {listener} already added to {this}.");
        }

        public void AddListener(Action<T0, T1> actionListener)
        {
            if (!actionListeners.Add(actionListener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {actionListener} already added to {this}.");
        }

        public void RemoveListener(ScriptableEventType2Listener<T0, T1> listener)
        {
            if (!listeners.Remove(listener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {listener} not found in {this}.");
        }

        public void RemoveListener(Action<T0, T1> actionListener)
        {
            if (!actionListeners.Remove(actionListener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {actionListener} not found in {this}.");
        }
    }
}