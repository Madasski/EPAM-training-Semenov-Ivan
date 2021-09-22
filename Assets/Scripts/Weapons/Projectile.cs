using UnityEngine;

namespace Game.Weapons
{
    public class Projectile : MonoBehaviour
    {
        public float Speed;
        public int DamageOnHit;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            var targetPosition = _rigidbody.position + transform.forward * Time.deltaTime * Speed;
            _rigidbody.MovePosition(targetPosition);
        }

        private void OnTriggerEnter(Collider other)
        {
            Damage(other);
            Destroy(gameObject);
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