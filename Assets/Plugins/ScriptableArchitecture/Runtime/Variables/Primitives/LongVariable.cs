using UnityEngine;

namespace SH.ScriptableArchitecture.Variables.Primitives
{
    [CreateAssetMenu(menuName = "SH/Scriptable Architecture/Variables/Primitives/Long", fileName = "New Long Variable")]
    public class LongVariable : BaseVariable<long>
    {
        public static LongVariable operator +(LongVariable variable, long value)
        {
            variable.Value += value;
            return variable;
        }

        public static LongVariable operator -(LongVariable variable, long value)
        {
            variable.Value -= value;
            return variable;
        }

        public static LongVariable operator *(LongVariable variable, long value)
        {
            variable.Value *= value;
            return variable;
        }

        public static LongVariable operator /(LongVariable variable, long value)
        {
            variable.Value /= value;
            return variable;
        }

        public static LongVariable operator ++(LongVariable variable)
        {
            variable.Value++;
            return variable;
        }

        public static LongVariable operator --(LongVariable variable)
        {
            variable.Value--;
            return variable;
        }
    }
}