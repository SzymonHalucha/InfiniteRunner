using UnityEngine;
using Game.Pooling;
using Game.Entities;
using SH.ScriptableArchitecture.Variables.Primitives;
using Random = UnityEngine.Random;

namespace Game.Managers
{
    public class PowerUpManager : MonoBehaviour
    {
        [SerializeField] private BoolVariable _isGameOver = null;
        [SerializeField] private PowerUpPool _powerUpPool = null;

        [Header("PowerUp Movement")]
        [SerializeField] private float _minMoveSpeed = 1f;
        [SerializeField] private float _maxMoveSpeed = 5f;

        [Header("PowerUp Spawn")]
        [SerializeField] private float _powerUpSpawnRate = 8f;
        [SerializeField] private float _spawnYOffset = 10f;
        [SerializeField] private float _spawnXStart = -13f;
        [SerializeField] private float _spawnXEnd = 13f;

        public bool IsInitialized { get; private set; } = false;

        private float _powerUpSpawnTimer = 0f;

        private void Awake()
        {
            if (!IsInitialized)
            {
                DontDestroyOnLoad(gameObject);
                _powerUpPool.Init(this.transform);
                IsInitialized = true;
            }
        }

        private void Update()
        {
            _powerUpSpawnTimer += Time.deltaTime;
            if (_powerUpSpawnTimer < _powerUpSpawnRate || _isGameOver.Value)
                return;

            _powerUpSpawnTimer = 0f;

            Vector3 randomStartPosition = new Vector3(Random.Range(_spawnXStart, _spawnXEnd), _spawnYOffset, 0f);
            float randomMoveSpeed = Random.Range(_minMoveSpeed, _maxMoveSpeed);

            BasePowerUp powerUp = _powerUpPool.GetFromPool(randomStartPosition);
            powerUp.Init(randomMoveSpeed);
        }
    }
}