using Composition;
using Core.Sound;
using UnityEngine;

namespace Game.Weapons
{
    public class Grenade : Projectile
    {
        [SerializeField] private ParticleSystem _explosionPrefab;
        [SerializeField] private AudioClip _explosionSound;
        [SerializeField] private float _initialSpeed;
        [SerializeField] private float _radius = 3f;
        [SerializeField] private float _damage = 120;
        private AudioManager _audioManager;

        protected override void Awake()
        {
            base.Awake();
            _audioManager = CompositionRoot.GetAudioManager();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        private void Start()
        {
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
            _audioManager.PlaySound(_explosionSound);
            var hits = Physics.SphereCastAll(transform.position, _radius, transform.position);

            if (hits.Length > 0)
            {
                foreach (var hit in hits)
                {
                    if (hit.collider.gameObject.TryGetComponent<IHealth>(out var health))
                    {
                        health.TakeDamage(_damage);
                    }
                }
            }
        }
    }
}