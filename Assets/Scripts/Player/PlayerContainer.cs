using UnityEngine;
using Game.Player.StateMachine;

namespace Game.Player
{
    public class PlayerContainer : MonoBehaviour
    {
        [SerializeField] private Transform _transform = null;
        [SerializeField] private BoxCollider2D _boxCollider2D = null;
        [SerializeField] private Rigidbody2D _rigidbody2D = null;
        [SerializeField] private PlayerStateMachine _stateMachine = null;
        [SerializeField] private PlayerInputs _inputs = null;
        [SerializeField] private PlayerStats _stats = null;
        [SerializeField] private GameObject _playerShield = null;

        public Transform Transform => _transform;
        public BoxCollider2D BoxCollider2D => _boxCollider2D;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public PlayerStateMachine StateMachine => _stateMachine;
        public PlayerInputs Inputs => _inputs;
        public PlayerStats Stats => _stats;
        public GameObject PlayerShield => _playerShield;
    }
}