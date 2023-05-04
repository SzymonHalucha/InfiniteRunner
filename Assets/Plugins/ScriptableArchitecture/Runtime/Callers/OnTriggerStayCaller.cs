using UnityEngine;

namespace SH.ScriptableArchitecture.Callers
{
    public class OnTriggerStayCaller : BaseCaller
    {
        private void OnTriggerStay(Collider other)
        {
            OnCall?.Invoke();
        }
    }
}