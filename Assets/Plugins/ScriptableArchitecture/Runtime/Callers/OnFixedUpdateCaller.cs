namespace SH.ScriptableArchitecture.Callers
{
    public class OnFixedUpdateCaller : BaseCaller
    {
        private void FixedUpdate()
        {
            OnCall?.Invoke();
        }
    }
}