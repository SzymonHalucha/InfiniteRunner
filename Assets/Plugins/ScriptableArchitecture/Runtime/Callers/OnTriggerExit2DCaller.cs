using UnityEngine;

namespace SH.ScriptableArchitecture.Callers
{
    public class OnTriggerExit2DCaller : BaseCaller
    {
        private void OnTriggerExit2D(Collider2D other)
        {
            OnCall?.Invoke();
        }
    }
}