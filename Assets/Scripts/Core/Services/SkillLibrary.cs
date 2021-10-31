using System.Collections.Generic;
using Madasski.Skills;
using UnityEngine;

namespace Core.Services
{
    public class SkillLibrary : MonoBehaviour
    {
        [SerializeField] private List<SkillData> _allSkills;
        public static SkillLibrary Instance;

        private void Awake()
        {
            Instance = this;
        }

        public ISkill GetSkillByType(SkillType skillType)
        {
            foreach (var skillData in _allSkills)
            {
                if (skillData.SkillType == skillType)
                {
                    return skillData.SkillSO;
                }
            }

            return null;
        }

        public Sprite GetSkillIconByType(SkillType skillType)
        {
            foreach (var skillData in _allSkills)
            {
                if (skillData.SkillType == skillType)
                {
                    return skillData.Icon;
                }
            }

            return null;
        }
    }
}