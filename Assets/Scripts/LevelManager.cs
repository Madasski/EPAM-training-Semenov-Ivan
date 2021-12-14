using System;
using Composition;
using Core;
using UnityEngine;

public class LevelManager : MonoBehaviour, ILevelManager
{
    public event Action LevelFailed;
    public event Action LevelStarted;
    public event Action LevelCompleted;

    public event Action<IEnemyCharacter> EnemyDied;
    public event Action<IEnemyCharacter> EnemySpawned;

    private Level _currentLevel;
    private ELevels _currentLevelType;
    private IResourceManager _resourceManager;
    private IPlayerCharacter _playerCharacter;
    private IObjectiveManager _objectiveManager;

    public IObjectiveManager ObjectiveManager => _objectiveManager;

    public void Awake()
    {
        _resourceManager = CompositionRoot.GetResourceManager();
        _playerCharacter = CompositionRoot.GetPlayerCharacter();
        _objectiveManager = new ObjectiveManager();
    }

    private void OnEnable()
    {
        _playerCharacter.Died += EndLevel;
        _objectiveManager.AllObjectivesCompleted += OnLevelCompleted;
    }

    private void OnDisable()
    {
        _playerCharacter.Died -= EndLevel;
        _objectiveManager.AllObjectivesCompleted -= OnLevelCompleted;
    }

    public void StartLevel(ELevels level)
    {
        _currentLevelType = level;

        SpawnPlayer();
        SpawnEnvironment(level);
        _objectiveManager.Init(_currentLevel.Objectives);

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