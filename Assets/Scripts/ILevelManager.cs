using System;

public interface ILevelManager
{
    event Action LevelStarted;
    event Action OnLevelEnd;
    // event Action OnLevelPausePress;
    event Action<IEnemyCharacter> EnemySpawned;
    event Action<IEnemyCharacter> EnemyDied;

    void StartLevel();
}