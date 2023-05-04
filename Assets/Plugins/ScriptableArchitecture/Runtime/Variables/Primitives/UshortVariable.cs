using UnityEngine;

namespace SH.ScriptableArchitecture.Variables.Primitives
{
    [CreateAssetMenu(menuName = "SH/Scriptable Architecture/Variables/Primitives/Ushort", fileName = "New Ushort Variable")]
    public class UshortVariable : BaseVariable<ushort>
    {
        public static UshortVariable operator +(UshortVariable variable, ushort value)
        {
            variable.Value += value;
            return variable;
        }

        public static UshortVariable operator -(UshortVariable variable, ushort value)
        {
            variable.Value -= value;
            return variable;
        }

        public static UshortVariable operator *(UshortVariable variable, ushort value)
        {
            variable.Value *= value;
            return variable;
        }

        public static UshortVariable operator /(UshortVariable variable, ushort value)
        {
            variable.Value /= value;
            return variable;
        }

        public static UshortVariable operator ++(UshortVariable variable)
        {
            variable.Value++;
            return variable;
        }

        public static UshortVariable operator --(UshortVariable variable)
        {
            variable.Value--;
            return variable;
        }
    }
}