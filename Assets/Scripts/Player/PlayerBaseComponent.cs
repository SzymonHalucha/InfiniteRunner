using UnityEngine;

namespace Game.Player
{
    public abstract class PlayerBaseComponent : MonoBehaviour
    {
        [SerializeField] protected PlayerContainer Player = null;
    }
}