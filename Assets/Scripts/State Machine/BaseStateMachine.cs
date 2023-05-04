using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.StateMachine
{
    public abstract class BaseStateMachine<T> : MonoBehaviour where T : UnityEngine.Object
    {
        private Dictionary<Type, BaseState<T>> _cachedStates;
        private BaseState<T> _currentState;
        private T _owner;

        public virtual void Init(T owner, BaseState<T>[] states)
        {
            this._owner = owner;
            _cachedStates = new Dictionary<Type, BaseState<T>>();

            foreach (BaseState<T> state in states)
                _cachedStates.Add(state.GetType(), Instantiate(state));
        }

        public virtual void DeInit()
        {
            _currentState?.OnExit(_owner);

            foreach (BaseState<T> state in _cachedStates.Values)
                Destroy(state);
        }

        protected virtual void FixedUpdate()
        {
            _currentState?.OnFixedUpdate(_owner);
        }

        protected virtual void Update()
        {
            _currentState?.OnUpdate(_owner);
        }

        public void ChangeState(Type type)
        {
            _currentState?.OnExit(_owner);
            _currentState = _cachedStates[type];
            _currentState.OnEnter(_owner);
        }
    }
}