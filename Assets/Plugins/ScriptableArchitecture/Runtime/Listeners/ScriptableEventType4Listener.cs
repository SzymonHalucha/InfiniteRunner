using UnityEngine;
using UnityEngine.Events;
using SH.ScriptableArchitecture.Events;

namespace SH.ScriptableArchitecture.Listeners
{
    public abstract class ScriptableEventType4Listener<T0, T1, T2, T3> : MonoBehaviour
    {
        [SerializeField] private ScriptableEventType4<T0, T1, T2, T3> scriptableEvent;
        [SerializeField] private UnityEvent<T0, T1, T2, T3> onEvent;

        private void OnEnable()
        {
            scriptableEvent.AddListener(OnEventRaised);
        }

        private void OnDisable()
        {
            scriptableEvent.RemoveListener(OnEventRaised);
        }

        public void OnEventRaised(T0 argument1, T1 argument2, T2 argument3, T3 argument4)
        {
            onEvent.Invoke(argument1, argument2, argument3, argument4);
        }
    }
}
