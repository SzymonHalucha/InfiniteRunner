using UnityEngine;

namespace Game.Player.StateMachine
{
    [CreateAssetMenu(menuName = "Game/State Machine/Disabled Player State", fileName = "New Disabled Player State")]
    public class DisabledPlayerState : BasePlayerState
    {
        public override void OnEnter(PlayerContainer player)
        {

        }

        public override void OnExit(PlayerContainer player)
        {

        }
    }
}