using UnityEngine;
using Game.Pooling;
using Game.Entities;
using SH.ScriptableArchitecture.Variables.Primitives;
using Random = UnityEngine.Random;

namespace Game.Managers
{
    public class RocksManager : MonoBehaviour
    {
        [SerializeField] private BoolVariable _isGameOver = null;
        [SerializeField] private RockPool _rocksPool = null;

        [Header("Rocks Movement")]
        [SerializeField] private float _minMoveSpeed = 1f;
        [SerializeField] private float _maxMoveSpeed = 5f;

        [Header("Rocks Scale")]
        [SerializeField] private float _rockScaleMin = 0.5f;
        [SerializeField] private float _rockScaleMax = 2.5f;

        [Header("Rocks Rotation")]
        [SerializeField] private float _minRotationSpeed = 10f;
        [SerializeField] private float _maxRotationSpeed = 50f;

        [Header("Rocks Spawn")]
        [SerializeField] private float _rockSpawnRate = 1f;
        [SerializeField] private float _spawnYOffset = 10f;
        [SerializeField] private float _spawnXStart = -13f;
        [SerializeField] private float _spawnXEnd = 13f;

        public bool IsInitialized { get; private set; } = false;

        private float _rockSpawnTimer = 0f;

        private void Awake()
        {
            if (!IsInitialized)
            {
                DontDestroyOnLoad(gameObject);
                _rocksPool.Init(this.transform);
                IsInitialized = true;
            }
        }

        private void Update()
        {
            _rockSpawnTimer += Time.deltaTime;
            if (_rockSpawnTimer < _rockSpawnRate || _isGameOver.Value)
                return;

            _rockSpawnTimer = 0f;

            Vector3 randomStartPosition = new Vector3(Random.Range(_spawnXStart, _spawnXEnd), _spawnYOffset, 0f);
            Vector3 randomScale = Vector3.one * Random.Range(_rockScaleMin, _rockScaleMax);
            float randomMoveSpeed = Random.Range(_minMoveSpeed, _maxMoveSpeed);
            float randomRotationSpeed = Random.Range(_minRotationSpeed, _maxRotationSpeed);

            Rock rock = _rocksPool.GetFromPool(randomStartPosition);
            rock.Init(randomMoveSpeed, randomRotationSpeed, randomScale);
        }
    }
}