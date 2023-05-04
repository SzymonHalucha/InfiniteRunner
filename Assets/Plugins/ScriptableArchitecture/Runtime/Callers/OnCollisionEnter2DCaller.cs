using UnityEngine;

namespace SH.ScriptableArchitecture.Callers
{
    public class OnCollisionEnter2DCaller : BaseCaller
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCall?.Invoke();
        }
    }
}