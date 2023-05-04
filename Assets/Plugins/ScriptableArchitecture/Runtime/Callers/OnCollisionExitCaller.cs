using UnityEngine;

namespace SH.ScriptableArchitecture.Callers
{
    public class OnCollisionExitCaller : BaseCaller
    {
        private void OnCollisionExit(Collision collision)
        {
            OnCall?.Invoke();
        }
    }
}