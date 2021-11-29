using System;

public interface ILevelManager
{
    event Action LevelStarted;
    event Action OnLevelEnd;
    event Action OnLevelPausePress;
    event Action<EnemyCharacter> EnemySpawned;
    event Action<EnemyCharacter> EnemyDied;

    void StartLevel();
}