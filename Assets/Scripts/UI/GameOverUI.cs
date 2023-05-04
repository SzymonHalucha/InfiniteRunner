using UnityEngine;
using UnityEngine.UI;
using SH.ScriptableArchitecture.Variables.Primitives;

namespace Game.UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private BoolVariable _isGameOver = null;
        [SerializeField] private IntVariable _points = null;
        [SerializeField] private GameObject _gameOverContainer = null;
        [SerializeField] private Text _gameOverText = null;
        [SerializeField] private Button _exitButton = null;

        private void Awake()
        {
            _exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        private void Start()
        {
            _isGameOver.AddListener(OnGameOver);
        }

        private void OnGameOver(bool isGameOver)
        {
            if (!isGameOver)
                return;

            _gameOverContainer.SetActive(true);
            _gameOverText.text = $"Game Over. \nYou scored {_points.Value} points!";
        }

        private void OnExitButtonClicked()
        {
            Application.Quit();
        }
    }
}