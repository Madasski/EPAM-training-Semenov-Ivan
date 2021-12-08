using Composition;
using Core.Services;
using UnityEngine;

namespace Madasski.Skills
{
    public class SkillController
    {
        private readonly Character _owner;
        private ISkillLibrary _skillLibrary;
        private SkillType[] _availableSkills;

        public SkillType[] AvailableSkills => _availableSkills;

        public SkillController(Character owner)
        {
            _availableSkills = GameConfig.PlayerSkills;
            _owner = owner;
            _skillLibrary = CompositionRoot.GetSkillLibrary();
        }

        public void UseSkill(int index)
        {
            var skill = _skillLibrary.GetSkillByType(_availableSkills[index]);
            var skillEffect = _skillLibrary.GetSkillEffectByType(_availableSkills[index]);

            if (skillEffect) GameObject.Instantiate(skillEffect, _owner.transform.position, _owner.transform.rotation);
            skill?.Use(_owner);
        }
    }
}