using UnityEngine;

namespace Game.Stats
{
    [System.Serializable]
    public class ConstStat
    {
        [SerializeField] private StatType _type = null;
        [SerializeField] private float _value = 100f;
        private float _modifierValue = 0;

        public StatType Type => _type;
        public float Value => _value + _modifierValue;

        public event System.Action<float> OnValueChanged;

        public void SetModifier(float value)
        {
            _modifierValue = value;
            OnValueChanged?.Invoke(Value);
        }

        public void Reset()
        {
            _modifierValue = 0;
            OnValueChanged?.Invoke(Value);
        }
    }
}