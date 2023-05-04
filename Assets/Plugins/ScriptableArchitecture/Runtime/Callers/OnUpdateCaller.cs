namespace SH.ScriptableArchitecture.Callers
{
    public class OnUpdateCaller : BaseCaller
    {
        private void Update()
        {
            OnCall?.Invoke();
        }
    }
}