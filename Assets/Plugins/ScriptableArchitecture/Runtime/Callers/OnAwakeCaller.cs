namespace SH.ScriptableArchitecture.Callers
{
    public class OnAwakeCaller : BaseCaller
    {
        private void Awake()
        {
            OnCall?.Invoke();
        }
    }
}