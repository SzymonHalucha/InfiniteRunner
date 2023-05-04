using System;
using System.Collections.Generic;
using UnityEngine;
using SH.ScriptableArchitecture.Listeners;

namespace SH.ScriptableArchitecture.Events
{
    [CreateAssetMenu(menuName = "SH/Scriptable Architecture/Events/Scriptable Event", fileName = "New Scriptable Event", order = 0)]
    public class ScriptableEvent : ScriptableObject
    {
        private HashSet<ScriptableEventListener> listeners = new();
        private HashSet<Action> actionListeners = new();

        public void Raise()
        {
            foreach (ScriptableEventListener listener in listeners)
                listener.OnEventRaised();

            foreach (Action actionListener in actionListeners)
                actionListener.Invoke();
        }

        public void AddListener(ScriptableEventListener listener)
        {
            if (!listeners.Add(listener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {listener} already added to {this}.");
        }

        public void AddListener(Action actionListener)
        {
            if (!actionListeners.Add(actionListener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {actionListener} already added to {this}.");
        }

        public void RemoveListener(ScriptableEventListener listener)
        {
            if (!listeners.Remove(listener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {listener} not found in {this}.");
        }

        public void RemoveListener(Action actionListener)
        {
            if (!actionListeners.Remove(actionListener))
                Debug.LogWarning($"(Scriptable Architecture) Listener {actionListener} not found in {this}.");
        }
    }
}