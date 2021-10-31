using UnityEngine;

namespace Madasski.Skills
{
    [CreateAssetMenu(fileName = "HealSelf skill", menuName = "Skills/New HealSelf Skill")]
    public class HealSkillSO : SkillSO
    {
        [SerializeField] private float _healthPerSecond = 10f;

        public override void Use(Character source = null, Character target = null)
        {
            source.Health.RestoreGradually(_healthPerSecond);
        }
    }
}