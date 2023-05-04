using UnityEngine;
using UnityEngine.UI;
using SH.ScriptableArchitecture.Variables.Primitives;

namespace Game.UI
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private BoolVariable _isGameOver = null;
        [SerializeField] private IntVariable _points = null;
        [SerializeField] private Text _timerText = null;

        private void Start()
        {
            _points.AddListener(OnPointsChanged);
        }

        private void OnPointsChanged(int points)
        {
            if (!_isGameOver.Value)
                _timerText.text = $"{points}";
        }
    }
}