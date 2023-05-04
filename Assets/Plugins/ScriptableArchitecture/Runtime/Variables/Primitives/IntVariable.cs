using UnityEngine;

namespace SH.ScriptableArchitecture.Variables.Primitives
{
    [CreateAssetMenu(menuName = "SH/Scriptable Architecture/Variables/Primitives/Int", fileName = "New Int Variable")]
    public class IntVariable : BaseVariable<int>
    {
        public static IntVariable operator +(IntVariable variable, int value)
        {
            variable.Value += value;
            return variable;
        }

        public static IntVariable operator -(IntVariable variable, int value)
        {
            variable.Value -= value;
            return variable;
        }

        public static IntVariable operator *(IntVariable variable, int value)
        {
            variable.Value *= value;
            return variable;
        }

        public static IntVariable operator /(IntVariable variable, int value)
        {
            variable.Value /= value;
            return variable;
        }

        public static IntVariable operator ++(IntVariable variable)
        {
            variable.Value++;
            return variable;
        }

        public static IntVariable operator --(IntVariable variable)
        {
            variable.Value--;
            return variable;
        }
    }
}