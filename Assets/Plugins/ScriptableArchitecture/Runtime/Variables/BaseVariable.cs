using System;
using UnityEngine;
using SH.ScriptableArchitecture.Events;

namespace SH.ScriptableArchitecture.Variables
{
    public abstract class BaseVariable<T> : ScriptableEventType1<T>
    {
        [SerializeField] private T initialValue;
        [NonSerialized] private T value;
        [NonSerialized] private bool isInitialized = false;

        public T Value
        {
            get
            {
                if (isInitialized)
                    return value;

                value = initialValue;
                isInitialized = true;
                Raise(value);
                return value;
            }
            set
            {
                if (isInitialized && this.value.Equals(value))
                {
                    Debug.LogWarning($"(Scriptable Architecture) Value of {this} is already {value}.");
                    return;
                }

                isInitialized = true;
                this.value = value;
                Raise(value);
            }
        }

        public static implicit operator T(BaseVariable<T> variable)
        {
            return variable.Value;
        }

        public static bool operator ==(BaseVariable<T> variable, T value)
        {
            return variable.Value.Equals(value);
        }

        public static bool operator !=(BaseVariable<T> variable, T value)
        {
            return !variable.Value.Equals(value);
        }

        public static bool operator ==(T value, BaseVariable<T> variable)
        {
            return variable.Value.Equals(value);
        }

        public static bool operator !=(T value, BaseVariable<T> variable)
        {
            return !variable.Value.Equals(value);
        }

        public static bool operator ==(BaseVariable<T> variable1, BaseVariable<T> variable2)
        {
            return variable1.Value.Equals(variable2.Value);
        }

        public static bool operator !=(BaseVariable<T> variable1, BaseVariable<T> variable2)
        {
            return !variable1.Value.Equals(variable2.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj is BaseVariable<T>)
                return Value.Equals(((BaseVariable<T>)obj).Value);
            else if (obj is T)
                return Value.Equals((T)obj);

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}