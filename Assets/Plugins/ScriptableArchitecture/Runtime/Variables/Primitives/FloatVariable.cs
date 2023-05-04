using UnityEngine;

namespace SH.ScriptableArchitecture.Variables.Primitives
{
    [CreateAssetMenu(menuName = "SH/Scriptable Architecture/Variables/Primitives/Float", fileName = "New Float Variable")]
    public class FloatVariable : BaseVariable<float>
    {
        public static FloatVariable operator +(FloatVariable variable, float value)
        {
            variable.Value += value;
            return variable;
        }

        public static FloatVariable operator -(FloatVariable variable, float value)
        {
            variable.Value -= value;
            return variable;
        }

        public static FloatVariable operator *(FloatVariable variable, float value)
        {
            variable.Value *= value;
            return variable;
        }

        public static FloatVariable operator /(FloatVariable variable, float value)
        {
            variable.Value /= value;
            return variable;
        }

        public static FloatVariable operator ++(FloatVariable variable)
        {
            variable.Value++;
            return variable;
        }

        public static FloatVariable operator --(FloatVariable variable)
        {
            variable.Value--;
            return variable;
        }
    }
}