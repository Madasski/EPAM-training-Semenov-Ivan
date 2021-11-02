using Core.Services;
using UnityEngine;

namespace Madasski.Skills
{
    public class SkillController
    {
        // private ISkill[] _availableSkills;
        private SkillType[] _availableSkills;
        private readonly Character _owner;

        public SkillType[] AvailableSkills => _availableSkills;

        public SkillController(Character owner)
        {
            _availableSkills = GameConfig.PlayerSkills;
            _owner = owner;
        }

        public void UseSkill(int index)
        {
            var skill = ServiceLocator.Instance.Get<SkillLibrary>().GetSkillByType(_availableSkills[index]);
            var skillEffect = ServiceLocator.Instance.Get<SkillLibrary>().GetSkillEffectByType(_availableSkills[index]);
            if (skillEffect) GameObject.Instantiate(skillEffect, _owner.transform.position, _owner.transform.rotation);
            skill?.Use(_owner);
        }
    }
}