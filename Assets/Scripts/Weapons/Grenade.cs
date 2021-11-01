using UnityEngine;

namespace Game.Weapons
{
    public class Grenade : Projectile
    {
        [SerializeField] private ParticleSystem _explosionPrefab;
        [SerializeField] private float _initialSpeed;
        [SerializeField] private float _radius = 3f;
        [SerializeField] private float _damage = 120;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _rigidbody.AddForce(transform.forward * _initialSpeed, ForceMode.Impulse);
        }

        protected override void Die()
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Explode();
            base.Die();
        }

        private void Explode()
        {
            var hits = Physics.SphereCastAll(transform.position, _radius, transform.position);

            if (hits.Length > 0)
            {
                foreach (var hit in hits)
                {
                    if (hit.collider.gameObject.TryGetComponent<Health>(out var health))
                    {
                        health.TakeDamage(_damage);
                    }
                }
            }
        }
    }
}