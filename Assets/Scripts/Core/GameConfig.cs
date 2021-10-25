using Madasski.Skills;
using Madasski.Stats;

public static class GameConfig
{
    public static readonly CharacterStats InitialPlayerStats = new CharacterStats()
    {
        Health = 100,
        Speed = 350,
        Power = 0
    };

    public static readonly CharacterStats EnemyStats = new CharacterStats()
    {
        Health = 20,
        Speed = 200,
        Power = 0
    };

    public static readonly ISkill[] PlayerSkills =
    {
        new DashSkill(),
        new HealSkill(), 
        new DamageAroundSkill() 
    };
}