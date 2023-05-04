using UnityEngine;
using Game.Stats;

namespace Game.Player.StateMachine
{
    [CreateAssetMenu(menuName = "Game/State Machine/Shield Player State", fileName = "New Shield Player State")]
    public class ShieldPlayerState : BasePlayerState
    {
        [SerializeField] private StatType _speed = null;
        [SerializeField] private float _shieldTime = 8f;
        [SerializeField] private string _shieldLayer = "Shield";
        [SerializeField] private string _playerLayer = "Default";

        private float _timer = 0f;

        public override void OnEnter(PlayerContainer player)
        {
            player.gameObject.layer = LayerMask.NameToLayer(_shieldLayer);
            player.PlayerShield.SetActive(true);
        }

        public override void OnExit(PlayerContainer player)
        {
            player.gameObject.layer = LayerMask.NameToLayer(_playerLayer);
            player.PlayerShield.SetActive(false);
            _timer = 0f;
        }

        public override void OnUpdate(PlayerContainer owner)
        {
            _timer += Time.deltaTime;
            if (_timer < _shieldTime)
                return;

            owner.StateMachine.ChangeState(typeof(NormalPlayerState));
        }

        public override void OnFixedUpdate(PlayerContainer player)
        {
            Vector2 input = player.Inputs.Mouse.ReadValue<Vector2>();
            player.Rigidbody2D.AddForce(new Vector2(input.x, 0) * player.Stats.GetConstStat(_speed).Value * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }
}