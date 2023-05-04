using UnityEngine;
using SH.ScriptableArchitecture.Variables.Primitives;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private BoolVariable _isGameOver = null;
        [SerializeField] private IntVariable _points = null;

        private float _timer;

        public bool IsInitialized { get; private set; } = false;

        private void Awake()
        {
            if (!IsInitialized)
            {
                DontDestroyOnLoad(gameObject);
                IsInitialized = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        private void Start()
        {
            _isGameOver.AddListener(GameOver);
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer <= 1f && !_isGameOver.Value)
                return;

            _timer = 0f;
            _points++;
            _points.Raise(_points);
        }

        public void GameOver(bool isGameOver)
        {
            if (!isGameOver)
                return;

            Cursor.lockState = CursorLockMode.None;
        }
    }
}