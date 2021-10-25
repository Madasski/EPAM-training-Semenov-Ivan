using Madasski.Skills;

namespace Madasski.Skills
{
    public class HealSkill : ISkill
    {
        public void Use(Character source = null, Character target = null)
        {
            source.Health.RestoreGradually(10f);
        }
    }
}