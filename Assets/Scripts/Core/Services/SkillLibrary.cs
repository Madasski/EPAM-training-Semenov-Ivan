using System.Collections.Generic;
using Madasski.Skills;
using UnityEngine;

namespace Core.Services
{
    public interface ISkillLibrary
    {
        ISkill GetSkillByType(SkillType skillType);
        Sprite GetSkillIconByType(SkillType skillType);
        GameObject GetSkillEffectByType(SkillType skillType);
    }

    public class SkillLibrary : MonoBehaviour, ISkillLibrary
    {
        [SerializeField] private List<SkillData> _allSkills;

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

        public GameObject GetSkillEffectByType(SkillType skillType)
        {
            foreach (var skillData in _allSkills)
            {
                if (skillData.SkillType == skillType)
                {
                    return skillData.Effect;
                }
            }

            return null;
        }
    }
}