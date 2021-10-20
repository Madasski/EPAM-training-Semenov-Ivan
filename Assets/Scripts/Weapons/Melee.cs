using UnityEngine;

namespace Game.Weapons
{
    public class Melee : Weapon
    {
        public Collider DamageCollider;
        public int HitDamage;

        protected override void Use(float additionalDamage = 0)
        {
            var hits = Physics.OverlapBox(DamageCollider.bounds.center, DamageCollider.bounds.extents / 2f);
            foreach (var hit in hits)
            {
                if (hit.TryGetComponent<IDamageable>(out var damageable))
                {
                    damageable.TakeDamage(HitDamage + additionalDamage);
                }
            }
        }
    }
}