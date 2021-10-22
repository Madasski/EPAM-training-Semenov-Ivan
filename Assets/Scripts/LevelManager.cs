using System;
<<<<<<< Updated upstream
using Core;
using Madasski;
=======
using Madasski.Core;
>>>>>>> Stashed changes
using UI;
using UnityEngine;
using UnityEngine.Serialization;

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
            var gameData = new GameData();
            SaveLoad.SaveGame(gameData);
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            var gameData = SaveLoad.LoadGame();
            Load(gameData);
        }
    }

    private void Load(GameData gameData)
    {
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