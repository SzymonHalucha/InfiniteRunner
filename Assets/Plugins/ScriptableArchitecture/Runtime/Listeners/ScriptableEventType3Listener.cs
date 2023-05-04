using UnityEngine;
using UnityEngine.Events;
using SH.ScriptableArchitecture.Events;

namespace SH.ScriptableArchitecture.Listeners
{
    public abstract class ScriptableEventType3Listener<T0, T1, T2> : MonoBehaviour
    {
        [SerializeField] private ScriptableEventType3<T0, T1, T2> scriptableEvent;
        [SerializeField] private UnityEvent<T0, T1, T2> onEvent;

        private void OnEnable()
        {
            scriptableEvent.AddListener(OnEventRaised);
        }

        private void OnDisable()
        {
            scriptableEvent.RemoveListener(OnEventRaised);
        }

        public void OnEventRaised(T0 argument1, T1 argument2, T2 argument3)
        {
            onEvent.Invoke(argument1, argument2, argument3);
        }
    }
}
