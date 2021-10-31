using UnityEngine;

namespace Madasski.Skills
{
    [CreateAssetMenu(fileName = "DamageAround", menuName = "Skills/New DamageAround Skill")]
    public class DamageAroundSkillSO : SkillSO
    {
        [SerializeField] private float _radius = 3f;
        [SerializeField] private float _damage = 300f;

        public override void Use(Character source = null, Character target = null)
        {
            var position = source.transform.position;
            var hits = Physics.SphereCastAll(position, _radius, position);

            if (hits.Length > 0)
            {
                foreach (var hit in hits)
                {
                    if (hit.collider.gameObject == source.gameObject) continue;

                    if (hit.collider.gameObject.TryGetComponent<Health>(out var health))
                    {
                        health.TakeDamage(_damage);
                    }
                }
            }
        }
    }
}