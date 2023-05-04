using UnityEngine;
using UnityEngine.Events;
using SH.ScriptableArchitecture.Events;

namespace SH.ScriptableArchitecture.Listeners
{
    public abstract class ScriptableEventType2Listener<T0, T1> : MonoBehaviour
    {
        [SerializeField] private ScriptableEventType2<T0, T1> scriptableEvent;
        [SerializeField] private UnityEvent<T0, T1> onEvent;

        private void OnEnable()
        {
            scriptableEvent.AddListener(OnEventRaised);
        }

        private void OnDisable()
        {
            scriptableEvent.RemoveListener(OnEventRaised);
        }

        public void OnEventRaised(T0 argument1, T1 argument2)
        {
            onEvent.Invoke(argument1, argument2);
        }
    }
}
