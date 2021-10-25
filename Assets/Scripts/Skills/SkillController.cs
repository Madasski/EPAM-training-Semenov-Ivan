namespace Madasski.Skills
{
    public class SkillController
    {
        private ISkill[] _availableSkills;
        private readonly Character _owner;

        public SkillController(Character owner)
        {
            _availableSkills = GameConfig.PlayerSkills;
            _owner = owner;
        }

        public void UseSkill(int index)
        {
            _availableSkills[index].Use(_owner);
        }
    }
}

