using System.Collections.Generic;
using UnityEngine;

namespace Game.Pooling
{
    public abstract class BasePool<T> : ScriptableObject where T : Component
    {
        [SerializeField] private T _prefab = null;
        [SerializeField, Range(1, 64)] private int _startSize = 16;

        private Transform _parent = null;
        private List<T> _active = new List<T>();
        private Stack<T> _inactive = new Stack<T>();

        public virtual void Init(Transform parent)
        {
            this._parent = parent;
            for (int i = 0; i < _startSize; i++)
                CreateObject();
        }

        public virtual void DeInit()
        {
            DestroyAllPoolObjects();
        }

        public T GetFromPool(Vector3 position, Quaternion rotation = default)
        {
            if (_inactive.Count <= 0)
                CreateObject();

            T objectFromStack = _inactive.Pop();
            objectFromStack.transform.position = position;
            objectFromStack.transform.rotation = rotation;
            objectFromStack.gameObject.SetActive(true);
            _active.Remove(objectFromStack);
            return objectFromStack;
        }

        public void ReturnToPool(T objectToReturn)
        {
            objectToReturn.gameObject.SetActive(false);
            _active.Remove(objectToReturn);
            _inactive.Push(objectToReturn);
        }

        public void DestroyAllPoolObjects()
        {
            foreach (T activeObject in _active)
                Destroy(activeObject.gameObject);

            foreach (T inactiveObject in _inactive)
                Destroy(inactiveObject.gameObject);

            _active.Clear();
            _inactive.Clear();
        }

        private void CreateObject()
        {
            T newObject = Instantiate(_prefab, Vector3.zero, Quaternion.identity, _parent);
            newObject.gameObject.SetActive(false);
            newObject.gameObject.name = $"{_prefab.name}{_active.Count + _inactive.Count + 1}";
            _inactive.Push(newObject);
        }
    }
}