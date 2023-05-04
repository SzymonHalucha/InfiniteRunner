namespace SH.ScriptableArchitecture.Callers
{
    public class OnEnableCaller : BaseCaller
    {
        private void OnEnable()
        {
            OnCall?.Invoke();
        }
    }
}