using System;
using System.Collections.Generic;
using UnityEngine;
using SH.ScriptableArchitecture.Listeners;

namespace SH.ScriptableArchitecture.Events
{
    public abstract class ScriptableEventType3<T0, T1, T2> : ScriptableObject
    {
        private HashSet<ScriptableEventType3Listener<T0, T1, T2>> listeners = new();
        private HashSet<Action<T0, T1, T2>> actionListeners = new();

        public void Raise(T0 argument1, T1 argument2, T2 argument3)
        {
            foreach (ScriptableEventType3Listener<T0, T1, T2> listener in listeners)
                listener.OnEventRaised(argument1, argument2, argument3);

            foreach (Action<T0, T1, T2> actionListener in actionListeners)
                actionListener.Invoke(argument1, argument2, argument3);
        }

        public void AddListener(ScriptableEventType3Listener<T0, T1, T2> listener)
        {
            if (!listeners.Add(listener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {listener} already added to {this}.");
        }

        public void AddListener(Action<T0, T1, T2> actionListener)
        {
            if (!actionListeners.Add(actionListener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {actionListener} already added to {this}.");
        }

        public void RemoveListener(ScriptableEventType3Listener<T0, T1, T2> listener)
        {
            if (!listeners.Remove(listener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {listener} not found in {this}.");
        }

        public void RemoveListener(Action<T0, T1, T2> actionListener)
        {
            if (!actionListeners.Remove(actionListener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {actionListener} not found in {this}.");
        }
    }
}