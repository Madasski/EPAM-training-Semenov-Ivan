using Madasski.Skills;
using Madasski.Stats;

public static class GameConfig
{
    public static readonly CharacterStats InitialPlayerStats = new CharacterStats()
    {
        Health = 10,
        Speed = 350,
        Power = 0
    };

    public static readonly CharacterStats EnemyStats = new CharacterStats()
    {
        Health = 100,
        Speed = 200,
        Power = 0
    };

    public static readonly SkillType[] PlayerSkills =
    {
        SkillType.Dash,
        SkillType.HealSelf,
        SkillType.DamageAround
    };
}