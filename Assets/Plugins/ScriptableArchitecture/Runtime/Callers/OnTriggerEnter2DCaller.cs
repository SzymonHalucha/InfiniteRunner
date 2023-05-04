using UnityEngine;

namespace SH.ScriptableArchitecture.Callers
{
    public class OnTriggerEnter2DCaller : BaseCaller
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnCall?.Invoke();
        }
    }
}