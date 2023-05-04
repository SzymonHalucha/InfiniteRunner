using UnityEngine;

namespace SH.ScriptableArchitecture.Callers
{
    public class OnCollisionStayCaller : BaseCaller
    {
        private void OnCollisionStay(Collision collision)
        {
            OnCall?.Invoke();
        }
    }
}