using UnityEngine;

namespace Game.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public Sprite Icon;
        public float FireRate;

        protected float _timeSinceLastUse = 999f;

        protected virtual void Update()
        {
            _timeSinceLastUse += Time.deltaTime;
        }

        public void TryUse(float additionalDamage = 0)
        {
            if (_timeSinceLastUse <= FireRate) return;
            Use(additionalDamage);
            _timeSinceLastUse = 0f;
        }

        protected abstract void Use(float additionalDamage = 0);
    }
}