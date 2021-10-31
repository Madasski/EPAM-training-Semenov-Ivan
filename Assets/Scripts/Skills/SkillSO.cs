using UnityEngine;

namespace Madasski.Skills
{
    public abstract class SkillSO : ScriptableObject, ISkill
    {
        public abstract void Use(Character source = null, Character target = null);
    }
}