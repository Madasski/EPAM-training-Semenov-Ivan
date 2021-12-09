using UnityEngine;

namespace Game.Weapons
{
    public class Fireball : Projectile
    {
        [SerializeField] private int _damage = 45;
        [SerializeField] private float _speed = 5;

        private void OnTriggerEnter(Collider other)
        {
            if (other.isTrigger) return;
            if (other.gameObject.TryGetComponent<IHealth>(out var health))
            {
                health.TakeDamage(_damage);
            }

            Die();
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            var targetPosition = _rigidbody.position + transform.forward * Time.deltaTime * _speed;
            _rigidbody.MovePosition(targetPosition);
        }

        protected override void Die()
        {
            Destroy(gameObject);
        }
    }
}