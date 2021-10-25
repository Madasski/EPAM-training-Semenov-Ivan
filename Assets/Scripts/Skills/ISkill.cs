namespace Madasski.Skills
{
    public interface ISkill
    {
        void Use(Character source = null, Character target = null);
    }
}