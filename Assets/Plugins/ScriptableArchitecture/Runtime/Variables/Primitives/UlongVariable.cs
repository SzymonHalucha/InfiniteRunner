using UnityEngine;

namespace SH.ScriptableArchitecture.Variables.Primitives
{
    [CreateAssetMenu(menuName = "SH/Scriptable Architecture/Variables/Primitives/Ulong", fileName = "New Ulong Variable")]
    public class UlongVariable : BaseVariable<ulong>
    {
        public static UlongVariable operator +(UlongVariable variable, ulong value)
        {
            variable.Value += value;
            return variable;
        }

        public static UlongVariable operator -(UlongVariable variable, ulong value)
        {
            variable.Value -= value;
            return variable;
        }

        public static UlongVariable operator *(UlongVariable variable, ulong value)
        {
            variable.Value *= value;
            return variable;
        }

        public static UlongVariable operator /(UlongVariable variable, ulong value)
        {
            variable.Value /= value;
            return variable;
        }

        public static UlongVariable operator ++(UlongVariable variable)
        {
            variable.Value++;
            return variable;
        }

        public static UlongVariable operator --(UlongVariable variable)
        {
            variable.Value--;
            return variable;
        }
    }
}