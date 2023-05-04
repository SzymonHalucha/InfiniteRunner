using UnityEngine;
using Game.Pooling;
using Game.Player;

namespace Game.Entities
{
    public abstract class BasePowerUp : MonoBehaviour
    {
        [SerializeField] protected PowerUpPool PowerUpPool = null;
        [SerializeField] protected Transform Transform = null;

        protected float MoveSpeed = 0f;

        public virtual void Init(float moveSpeed)
        {
            MoveSpeed = moveSpeed;
        }

        protected virtual void Update()
        {
            if (!gameObject.activeSelf)
                return;

            Transform.position += Vector3.down * MoveSpeed * Time.deltaTime;
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                OnPlayerCollision(other.GetComponent<PlayerContainer>());

            PowerUpPool.ReturnToPool(this);
        }

        protected abstract void OnPlayerCollision(PlayerContainer playerContainer);
    }
}