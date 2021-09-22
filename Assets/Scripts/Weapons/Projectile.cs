using UnityEngine;

namespace Game.Weapons
{
    public class Projectile: MonoBehaviour
    {
        public float Speed;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            // transform.position += transform.forward*Time.deltaTime*Speed;
            var targetPosition = _rigidbody.position + transform.forward * Time.deltaTime * Speed;
            _rigidbody.MovePosition(targetPosition);
        }
    }
}

