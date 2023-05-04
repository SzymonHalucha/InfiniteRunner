using UnityEngine;
using Game.Player.StateMachine;
using SH.ScriptableArchitecture.Variables.Primitives;

namespace Game.Player
{
    public class PlayerCollisionChecker : PlayerBaseComponent
    {
        [SerializeField] private BoolVariable _isGameOver = null;
        [SerializeField] private string _rockTag = "Rock";

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag(_rockTag))
                return;

            _isGameOver.Value = true;
            Player.StateMachine.ChangeState(typeof(DisabledPlayerState));
        }
    }
}