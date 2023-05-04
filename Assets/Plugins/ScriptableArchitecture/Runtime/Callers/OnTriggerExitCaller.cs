using UnityEngine;

namespace SH.ScriptableArchitecture.Callers
{
    public class OnTriggerExitCaller : BaseCaller
    {
        private void OnTriggerExit(Collider other)
        {
            OnCall?.Invoke();
        }
    }
}