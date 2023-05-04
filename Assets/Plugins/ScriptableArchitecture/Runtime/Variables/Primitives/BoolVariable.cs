using UnityEngine;

namespace SH.ScriptableArchitecture.Variables.Primitives
{
    [CreateAssetMenu(menuName = "SH/Scriptable Architecture/Variables/Primitives/Bool", fileName = "New Bool Variable")]
    public class BoolVariable : BaseVariable<bool>
    {
        public static BoolVariable operator !(BoolVariable variable)
        {
            variable.Value = !variable.Value;
            return variable;
        }

        public static BoolVariable operator &(BoolVariable variable, bool value)
        {
            variable.Value &= value;
            return variable;
        }

        public static BoolVariable operator |(BoolVariable variable, bool value)
        {
            variable.Value |= value;
            return variable;
        }

        public static BoolVariable operator ^(BoolVariable variable, bool value)
        {
            variable.Value ^= value;
            return variable;
        }
    }
}