using Core.Services;

namespace Madasski.Skills
{
    public class SkillController
    {
        // private ISkill[] _availableSkills;
        private SkillType[] _availableSkills;
        private readonly Character _owner;

        public SkillController(Character owner)
        {
            _availableSkills = GameConfig.PlayerSkills;
            _owner = owner;
        }

        public void UseSkill(int index)
        {
            var skill = SkillLibrary.Instance.GetSkillByType(_availableSkills[index]);
            skill?.Use(_owner);
        }
    }
}