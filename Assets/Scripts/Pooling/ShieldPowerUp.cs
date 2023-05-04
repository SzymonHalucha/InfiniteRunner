using Game.Player;
using Game.Player.StateMachine;

namespace Game.Entities
{
    public class ShieldPowerUp : BasePowerUp
    {
        protected override void OnPlayerCollision(PlayerContainer playerContainer)
        {
            playerContainer.StateMachine.ChangeState(typeof(ShieldPlayerState));
        }
    }
}