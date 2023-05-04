using UnityEngine;
using UnityEngine.Events;

namespace SH.ScriptableArchitecture.Callers
{
    public abstract class BaseCaller : MonoBehaviour
    {
        [SerializeField] protected UnityEvent OnCall;
    }
}