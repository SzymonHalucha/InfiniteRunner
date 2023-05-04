using UnityEngine;

namespace SH.ScriptableArchitecture.Variables.Primitives
{
    [CreateAssetMenu(menuName = "SH/Scriptable Architecture/Variables/Primitives/Char", fileName = "New Char Variable")]
    public class CharVariable : BaseVariable<char>
    {
        public static CharVariable operator +(CharVariable variable, char value)
        {
            variable.Value += value;
            return variable;
        }

        public static CharVariable operator -(CharVariable variable, char value)
        {
            variable.Value -= value;
            return variable;
        }

        public static CharVariable operator *(CharVariable variable, char value)
        {
            variable.Value *= value;
            return variable;
        }

        public static CharVariable operator /(CharVariable variable, char value)
        {
            variable.Value /= value;
            return variable;
        }

        public static CharVariable operator ++(CharVariable variable)
        {
            variable.Value++;
            return variable;
        }

        public static CharVariable operator --(CharVariable variable)
        {
            variable.Value--;
            return variable;
        }
    }
}