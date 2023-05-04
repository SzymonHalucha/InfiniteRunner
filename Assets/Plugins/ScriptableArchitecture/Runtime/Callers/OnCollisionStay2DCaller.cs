using UnityEngine;

namespace SH.ScriptableArchitecture.Callers
{
    public class OnCollisionStay2DCaller : BaseCaller
    {
        private void OnCollisionStay2D(Collision2D collision)
        {
            OnCall?.Invoke();
        }
    }
}