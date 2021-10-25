using UnityEngine;

namespace Madasski.Skills
{
    public class DamageAroundSkill : ISkill
    {
        public void Use(Character source = null, Character target = null)
        {
            var position = source.transform.position;
            var radius = 3f;
            var damage = 300f;

            var hits = Physics.SphereCastAll(position, radius, position);

            Debug.Log(hits.Length);
            if (hits.Length > 0)
            {
                foreach (var hit in hits)
                {
                    if (hit.collider.gameObject == source.gameObject) continue;

                    if (hit.collider.gameObject.TryGetComponent<Health>(out var health))
                    {
                        health.TakeDamage(damage);
                    }
                }
            }
        }
    }
}