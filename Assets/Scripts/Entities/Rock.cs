using UnityEngine;
using Game.Pooling;

namespace Game.Entities
{
    public class Rock : MonoBehaviour
    {
        [SerializeField] private RockPool _rocksPool = null;
        [SerializeField] private Transform _transform = null;

        private float _moveSpeed = 0f;
        private float _rotationSpeed = 0f;

        public void Init(float moveSpeed, float rotationSpeed, Vector3 scale)
        {
            _moveSpeed = moveSpeed;
            _rotationSpeed = rotationSpeed;
            _transform.localScale = scale;
        }

        private void Update()
        {
            if (!gameObject.activeSelf)
                return;

            _transform.position += Vector3.down * _moveSpeed * Time.deltaTime;
            _transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _rocksPool.ReturnToPool(this);
        }
    }
}