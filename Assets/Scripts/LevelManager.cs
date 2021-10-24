using System;
using Core.Saving;
using Madasski;
using UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public event Action OnLevelEnd;
    public event Action OnLevelPausePress;

    public GameUI UIPrefab;
    public GameObject LevelPrefab;
    public PlayerCharacter PlayerPrefab;
    public EnemySpawner EnemySpawnerPrefab;
    public CameraFollow CameraPrefab;

    private GameUI _ui;
    private PlayerCharacter _player;
    private EnemySpawner _enemySpawner;
    private CameraFollow _cameraFollow;
    private GameFlow _gameFlow;

    private void Awake()
    {
        Init();
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
            Save();
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            Load();
        }
    }

    private void Save()
    {
        var gameData = new GameData();
        _player.Save(gameData);
        SaveLoad.SaveGameData(gameData);
    }

    private void Load()
    {
        var gameData = SaveLoad.LoadGameData();
        Debug.Log(gameData.CharacterStats.Health);
        _player.Load(gameData);
    }

    private void Init()
    {
        _player = Instantiate(PlayerPrefab);
        _cameraFollow = Instantiate(CameraPrefab);
        _enemySpawner = Instantiate(EnemySpawnerPrefab);
        _ui = Instantiate(UIPrefab);
        Instantiate(LevelPrefab);
        _gameFlow = new GameFlow(_player, _enemySpawner);

        _cameraFollow.SetTarget(_player.transform);
        _enemySpawner.SetPlayer(_player);

        _ui.GetComponentInChildren<HUD>().SetPlayer(_player);
        _ui.LevelUpScreen.PlayerCharacter = _player;
        OnLevelEnd += _ui.ShowLevelEndScreen;
        OnLevelPausePress += _ui.TogglePauseScreen;
        _player.ExperienceManager.LevelGained += _ui.ShowLevelUpScreen;

        _enemySpawner.EnemySpawned += _ui.GetComponentInChildren<EnemyHealthBarManager>().DrawHealthBarForEnemy;

        _player.LookTarget = _ui.GetComponentInChildren<CrosshairUI>().transform;
        _player.Died += EndLevel;
    }

    private void EndLevel(Character player)
    {
        OnLevelEnd?.Invoke();
    }
}