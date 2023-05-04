using UnityEngine;

namespace SH.ScriptableArchitecture.Callers
{
    public class OnCollisionExit2DCaller : BaseCaller
    {
        private void OnCollisionExit2D(Collision2D collision)
        {
            OnCall?.Invoke();
        }
    }
}