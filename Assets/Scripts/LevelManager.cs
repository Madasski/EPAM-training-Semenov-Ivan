using System;
using Composition;
using Core;
using UnityEngine;

public class LevelManager : MonoBehaviour, ILevelManager
{
    public event Action LevelFailed;
    public event Action LevelStarted;
    public event Action LevelCompleted;

    public event Action<IEnemyCharacter> EnemySpawned;
    public event Action<IEnemyCharacter> EnemyDied;

    private IResourceManager _resourceManager;
    private IPlayerCharacter _playerCharacter;
    private Level _currentLevel;
    private ELevels _currentLevelType;

    public void Awake()
    {
        _resourceManager = CompositionRoot.GetResourceManager();
        _playerCharacter = CompositionRoot.GetPlayerCharacter();
    }

    private void OnEnable()
    {
        _playerCharacter.Died += EndLevel;
    }

    private void OnDisable()
    {
        _playerCharacter.Died -= EndLevel;
    }

    public void StartLevel(ELevels level)
    {
        _currentLevelType = level;

        SpawnPlayer();
        SpawnEnvironment(level);

        LevelStarted?.Invoke();
    }

    public ELevels GetCurrentLevel()
    {
        return _currentLevelType;
    }

    private void SpawnEnvironment(ELevels level)
    {
        var levelPrefab = _resourceManager.GetPrefab<ELevels, Level>(level);
        _currentLevel = Instantiate(levelPrefab);

        foreach (var spawner in _currentLevel.EnemySpawners)
        {
            //todo don't forget to unsubscribe later
            spawner.EnemySpawned += OnEnemySpawned;
            spawner.EnemyDied += OnEnemyDied;
        }
    }

    private void SpawnPlayer()
    {
        _playerCharacter.Init();
    }

    private void EndLevel(ICharacter player)
    {
        LevelFailed?.Invoke();
    }

    private void OnLevelCompleted()
    {
        LevelCompleted?.Invoke();
    }

    private void OnEnemySpawned(EnemyCharacter enemyCharacter)
    {
        EnemySpawned?.Invoke(enemyCharacter);
    }

    private void OnEnemyDied(EnemyCharacter enemyCharacter)
    {
        EnemyDied?.Invoke(enemyCharacter);
        _playerCharacter.ExperienceManager.GainExperience(enemyCharacter.experienceForKill);
    }
}