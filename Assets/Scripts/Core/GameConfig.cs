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

    private static readonly ELevels[] Levels =
    {
        ELevels.Level01,
        ELevels.Level02,
        ELevels.Level03
    };

    public static ELevels GetNextLevelAfter(ELevels currentLevel)
    {
        var nextLevel = ELevels.Level01;

        for (var i = 0; i < Levels.Length - 1; i++)
        {
            if (Levels[i] == currentLevel)
            {
                nextLevel = Levels[i + 1];
            }
        }

        return nextLevel;
    }
}