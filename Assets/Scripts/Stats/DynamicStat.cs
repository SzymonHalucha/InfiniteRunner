using UnityEngine;

namespace Game.Stats
{
    [System.Serializable]
    public class DynamicStat
    {
        [SerializeField] private StatType _type = null;
        [SerializeField] private float _startValue = 100f;
        [SerializeField] private float _currentValue = 100f;
        [SerializeField] private float _minValue = 0;
        [SerializeField] private float _maxValue = 100f;
        private float _modifierValue = 0;

        public StatType Type => _type;
        public float StartValue => _startValue;
        public float CurrentValue => _currentValue + _modifierValue;
        public float MinValue => _minValue;
        public float MaxValue => _maxValue;

        public event System.Action<float> OnValueChanged;

        public void Subtract(float value)
        {
            _currentValue = Mathf.Max(_currentValue - value, MinValue);
            OnValueChanged?.Invoke(CurrentValue);
        }

        public void Add(float value)
        {
            _currentValue = Mathf.Min(_currentValue + value, MaxValue);
            OnValueChanged?.Invoke(CurrentValue);
        }

        public void Set(float value)
        {
            _currentValue = Mathf.Clamp(value, MinValue, MaxValue);
            OnValueChanged?.Invoke(CurrentValue);
        }

        public void SetModifier(float value)
        {
            _modifierValue = value;
            OnValueChanged?.Invoke(CurrentValue);
        }

        public void SetModifierPercentage(float value)
        {
            _modifierValue = (value) * (MaxValue - MinValue);
            OnValueChanged?.Invoke(CurrentValue);
        }

        public void Reset()
        {
            _currentValue = _startValue;
            _modifierValue = 0;
            OnValueChanged?.Invoke(CurrentValue);
        }
    }
}