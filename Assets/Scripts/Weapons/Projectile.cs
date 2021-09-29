using System;
using Madasski.Core;
using UnityEngine;

namespace Game.Weapons
{
    public class Projectile : MonoBehaviour
    {
        public GameObject Prefab;
        public float Speed;
        public int DamageOnHit;
        public float Lifespan = 1f;

        private Rigidbody _rigidbody;
        private float _lifespan;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            _lifespan = Lifespan;
        }

        private void Update()
        {
            _lifespan -= Time.deltaTime;
            if (_lifespan <= 0) Die();
        }

        private void Die()
        {
            ObjectPool.Instance.ReturnObjectToPool(this);
        }

        private void FixedUpdate()
        {
            var targetPosition = _rigidbody.position + transform.forward * Time.deltaTime * Speed;
            _rigidbody.MovePosition(targetPosition);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.isTrigger) return;
            Damage(other);
            Die();
        }

        private void Damage(Collider other)
        {
            if (other.gameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(DamageOnHit);
            }
        }
    }
}