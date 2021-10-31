using UnityEngine;

namespace Madasski.Skills
{
    [CreateAssetMenu(fileName = "Dash skill", menuName = "Skills/New Dash Skill")]
    public class DashSkillSO : SkillSO
    {
        [SerializeField] private float _distance = 4f;

        public override void Use(Character source = null, Character target = null)
        {
            source.Mover.DashAtLookDirection(_distance);
        }
    }
}