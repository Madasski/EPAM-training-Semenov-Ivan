using System;
using Core.Saving;
using UnityEngine;

public class ExperienceManager : ISaveLoad
{
    public event Action LevelGained;

    private const int ExperiencePerLevel = 12;
    private int _experience = 0;
    private int _level = 1;

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
        LevelGained?.Invoke();
    }

    public void Save(GameData gameData)
    {
        gameData.PlayerExperience = _experience;
    }

    public void Load(GameData gameData)
    {
        _experience = 0;
        _level = 1;
        GainExperience(gameData.PlayerExperience);
    }
}