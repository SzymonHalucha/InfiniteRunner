using UnityEngine;

namespace SH.ScriptableArchitecture.Callers
{
    public class OnTriggerStay2DCaller : BaseCaller
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            OnCall?.Invoke();
        }
    }
}