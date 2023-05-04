namespace SH.ScriptableArchitecture.Callers
{
    public class OnLateUpdateCaller : BaseCaller
    {
        private void LateUpdate()
        {
            OnCall?.Invoke();
        }
    }
}