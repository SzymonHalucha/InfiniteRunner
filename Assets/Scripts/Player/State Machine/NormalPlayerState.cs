using UnityEngine;
using Game.Stats;

namespace Game.Player.StateMachine
{
    [CreateAssetMenu(menuName = "Game/State Machine/Normal Player State", fileName = "New Normal Player State")]
    public class NormalPlayerState : BasePlayerState
    {
        [SerializeField] private StatType _speed = null;

        public override void OnEnter(PlayerContainer player)
        {

        }

        public override void OnExit(PlayerContainer player)
        {

        }

        public override void OnFixedUpdate(PlayerContainer player)
        {
            Vector2 input = player.Inputs.Mouse.ReadValue<Vector2>();
            player.Rigidbody2D.AddForce(new Vector2(input.x, 0) * player.Stats.GetConstStat(_speed).Value * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }
}