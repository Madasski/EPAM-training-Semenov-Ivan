using Madasski.Core;
using UnityEngine;

namespace Game.Weapons
{
    public abstract class Projectile : MonoBehaviour
    {
        public float Lifespan = 1f;

        protected Rigidbody _rigidbody;
        private float _lifespan;

        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        

        protected virtual void OnEnable()
        {
            _lifespan = Lifespan;
        }

        private void Update()
        {
            _lifespan -= Time.deltaTime;
            if (_lifespan <= 0) Die();
        }

        protected virtual void Die()
        {
            ObjectPool.Instance.ReturnObjectToPool(this);
        }

        protected virtual void FixedUpdate()
        {
        }
    }
}