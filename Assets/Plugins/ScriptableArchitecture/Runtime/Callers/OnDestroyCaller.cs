namespace SH.ScriptableArchitecture.Callers
{
    public class OnDestroyCaller : BaseCaller
    {
        private void OnDestroy()
        {
            OnCall?.Invoke();
        }
    }
}