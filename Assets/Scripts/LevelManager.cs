using System;
using Composition;
using Core;
using UnityEngine;

public class LevelManager : ILevelManager
{
    public event Action LevelStarted;
    public event Action OnLevelEnd;
    public event Action OnLevelPausePress;
    public event Action<EnemyCharacter> EnemySpawned;
    public event Action<EnemyCharacter> EnemyDied;

    // public GameUI UIPrefab;
    // public GameObject LevelPrefab;
    // public PlayerCharacter PlayerPrefab;
    //
    // public EnemySpawner EnemySpawnerPrefab;

    // public CameraFollow CameraPrefab;
    // public SkillLibrary SkillLibraryPrefab;
    // public AudioManager AudioManagerPrefab;

    // private GameUI _ui;
    // private PlayerCharacter _player;

    // private EnemySpawner _enemySpawner;

    // private CameraFollow _cameraFollow;
    // private GameFlow _gameFlow;

    // private SkillLibrary _skillLibrary;
    // private AudioManager _audioManager;
    // [SerializeField] private AudioClip _menuMusic;

    private IResourceManager _resourceManager;
    private PlayerCharacter _playerCharacter;
    private Level _currentLevel;

    public LevelManager()
    {
        _resourceManager = CompositionRoot.GetResourceManager();
        _playerCharacter = CompositionRoot.GetPlayerCharacter();
    }

    private void Start()
    {
        // _audioManager.PlayMusic(_menuMusic);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnLevelPausePress?.Invoke();
        }

        //debug
        if (Input.GetKeyDown(KeyCode.F5))
        {
            // Save();
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            // Load();
        }
    }

    // private void Save()
    // {
    //     var gameData = new GameData();
    //     _player.Save(gameData);
    //     SaveLoad.SaveGameData(gameData);
    // }

    // private void Load()
    // {
    //     var gameData = SaveLoad.LoadGameData();
    //     _player.Load(gameData);
    // }

    private void Init()
    {
        // _skillLibrary = Instantiate(SkillLibraryPrefab);

        // _gameFlow = new GameFlow(_player, _enemySpawner);

        // _ui.LevelUpScreen.PlayerCharacter = _player;
        // OnLevelEnd += _ui.ShowLevelEndScreen;
        // OnLevelPausePress += _ui.TogglePauseScreen;
        // _player.ExperienceManager.LevelGained += _ui.ShowLevelUpScreen;
        //
        // _enemySpawner.EnemySpawned += _ui.GetComponentInChildren<EnemyHealthBarManager>().DrawHealthBarForEnemy;
        //
        // _player.LookTarget = _ui.GetComponentInChildren<CrosshairUI>().transform;
        // _player.Died += EndLevel;
    }

    public void StartLevel()
    {
        SpawnPlayer();
        SpawnEnvironment();

        LevelStarted?.Invoke();
    }

    private void SpawnEnvironment()
    {
        var levelPrefab = _resourceManager.GetPrefab<ELevels, Level>(ELevels.Level01);
        _currentLevel = GameObject.Instantiate(levelPrefab);

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

    private void EndLevel(Character player)
    {
        OnLevelEnd?.Invoke();
    }

    private void OnEnemySpawned(EnemyCharacter enemyCharacter)
    {
        EnemySpawned?.Invoke(enemyCharacter);
    }

    private void OnEnemyDied(EnemyCharacter enemyCharacter)
    {
        EnemyDied?.Invoke(enemyCharacter);
    }
}