using UnityEngine;
using Game.StateMachine;

namespace Game.Player.StateMachine
{
    public class PlayerStateMachine : BaseStateMachine<PlayerContainer>
    {
        [SerializeField] private PlayerContainer _playerContainer = null;
        [SerializeField] private BasePlayerState[] _states = new BasePlayerState[0];

        public void OnEnable()
        {
            Init(_playerContainer, _states);
            ChangeState(typeof(NormalPlayerState));
        }

        public void OnDisable()
        {
            DeInit();
        }
    }
}