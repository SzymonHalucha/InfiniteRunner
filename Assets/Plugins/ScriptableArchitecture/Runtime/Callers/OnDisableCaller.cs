namespace SH.ScriptableArchitecture.Callers
{
    public class OnDisableCaller : BaseCaller
    {
        private void OnDisable()
        {
            OnCall?.Invoke();
        }
    }
}