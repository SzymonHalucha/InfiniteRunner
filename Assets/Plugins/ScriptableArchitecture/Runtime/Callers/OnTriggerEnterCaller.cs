using UnityEngine;

namespace SH.ScriptableArchitecture.Callers
{
    public class OnTriggerEnterCaller : BaseCaller
    {
        private void OnTriggerEnter(Collider other)
        {
            OnCall?.Invoke();
        }
    }
}