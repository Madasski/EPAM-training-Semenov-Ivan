using UnityEngine;

namespace Game.Weapons
{
    public class Bullet : Projectile
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _speed;

        private void OnTriggerEnter(Collider other)
        {
            if (other.isTrigger) return;
            Damage(other);
            Die();
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            var targetPosition = _rigidbody.position + transform.forward * Time.deltaTime * _speed;
            _rigidbody.MovePosition(targetPosition);
        }

        private void Damage(Collider other)
        {
            if (other.gameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(_damage);
            }
        }
    }
}