namespace SH.ScriptableArchitecture.Callers
{
    public class OnStartCaller : BaseCaller
    {
        private void Start()
        {
            OnCall?.Invoke();
        }
    }
}