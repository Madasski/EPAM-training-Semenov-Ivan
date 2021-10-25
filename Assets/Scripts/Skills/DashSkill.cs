namespace Madasski.Skills
{
    public class DashSkill : ISkill
    {
        public void Use(Character source = null, Character target = null)
        {
            source.Mover.DashAtLookDirection(4f);
        }
    }
}