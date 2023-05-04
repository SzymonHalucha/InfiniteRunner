using UnityEngine;

namespace SH.ScriptableArchitecture.Callers
{
    public class OnCollisionEnterCaller : BaseCaller
    {
        private void OnCollisionEnter(Collision collision)
        {
            OnCall?.Invoke();
        }
    }
}