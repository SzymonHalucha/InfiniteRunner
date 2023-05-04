using System;
using System.Collections.Generic;
using UnityEngine;
using SH.ScriptableArchitecture.Listeners;

namespace SH.ScriptableArchitecture.Events
{
    public abstract class ScriptableEventType4<T0, T1, T2, T3> : ScriptableObject
    {
        private HashSet<ScriptableEventType4Listener<T0, T1, T2, T3>> listeners = new();
        private HashSet<Action<T0, T1, T2, T3>> actionListeners = new();

        public void Raise(T0 argument1, T1 argument2, T2 argument3, T3 argument4)
        {
            foreach (ScriptableEventType4Listener<T0, T1, T2, T3> listener in listeners)
                listener.OnEventRaised(argument1, argument2, argument3, argument4);

            foreach (Action<T0, T1, T2, T3> actionListener in actionListeners)
                actionListener.Invoke(argument1, argument2, argument3, argument4);
        }

        public void AddListener(ScriptableEventType4Listener<T0, T1, T2, T3> listener)
        {
            if (!listeners.Add(listener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {listener} already added to {this}.");
        }

        public void AddListener(Action<T0, T1, T2, T3> actionListener)
        {
            if (!actionListeners.Add(actionListener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {actionListener} already added to {this}.");
        }

        public void RemoveListener(ScriptableEventType4Listener<T0, T1, T2, T3> listener)
        {
            if (!listeners.Remove(listener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {listener} not found in {this}.");
        }

        public void RemoveListener(Action<T0, T1, T2, T3> actionListener)
        {
            if (!actionListeners.Remove(actionListener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {actionListener} not found in {this}.");
        }
    }
}