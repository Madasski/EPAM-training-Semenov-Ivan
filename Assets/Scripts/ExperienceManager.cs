using System;

public class ExperienceManager : IExperienceManager
{
    public event Action<int> LevelGained;

    private const int ExperiencePerLevel = 55;
    private int _experience = 0;
    private int _level = 1;

    public int CurrentLevel => _level;
    public int Experience => _experience;

    public void Init(int initialExperience, int initialLevel)
    {
        _experience = initialExperience;
        _level = initialLevel;
    }

    public void GainExperience(int amount)
    {
        if (amount <= 0) return;
        _experience += amount;

        while (_experience > ExperiencePerLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        _level++;
        _experience -= ExperiencePerLevel;
        LevelGained?.Invoke(_level);
    }
}