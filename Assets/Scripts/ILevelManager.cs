using System;

public interface ILevelManager
{
    event Action LevelFailed;
    event Action LevelStarted;
    event Action LevelCompleted;

    event Action<IEnemyCharacter> EnemySpawned;
    event Action<IEnemyCharacter> EnemyDied;

    IObjectiveManager ObjectiveManager { get; }

    void StartLevel(ELevels level);
    ELevels GetCurrentLevel();
}