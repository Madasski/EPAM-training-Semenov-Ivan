using System;

public interface IExperienceManager
{
    event Action<int> LevelGained;

    int CurrentLevel { get; }
    int Experience { get; }

    void Init(int initialExperience, int initialLevel);
    void GainExperience(int amount);
}