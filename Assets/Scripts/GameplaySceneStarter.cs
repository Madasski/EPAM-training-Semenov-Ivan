using Composition;
using Core;
using Core.Saving;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplaySceneStarter : MonoBehaviour
{
    private ICameraFollow _camera;
    private IPlayerCharacter _player;
    private ILevelManager _levelManager;
    private ISaveLoadManager _saveLoadManager;
    private IResourceManager _resourceManager;
    private IHealthBarDrawer _healthBarDrawer;

    private IHUD _hud;
    private IPauseMenu _pauseMenu;
    private ILevelUpScreen _levelUpScreen;
    private ILevelEndScreen _levelEndScreen;

    private void Awake()
    {
        _camera = CompositionRoot.GetPlayerCamera();
        _player = CompositionRoot.GetPlayerCharacter();
        _levelManager = CompositionRoot.GetLevelManager();
        _saveLoadManager = CompositionRoot.GetSaveLoadManager();
        _resourceManager = CompositionRoot.GetResourceManager();

        _hud = CompositionRoot.GetHUD();
        _pauseMenu = CompositionRoot.GetPauseMenu();
        _levelUpScreen = CompositionRoot.GetLevelUpScreen();
        _levelEndScreen = CompositionRoot.GetLevelEndScreen();
        _healthBarDrawer = CompositionRoot.GetHealthBarDrawer();

        _camera.SetTarget(_player.Mover.Transform);
        _hud.SetPlayer(_player);
        _hud.SetObjectiveManager(_levelManager.ObjectiveManager);

        _hud.Show();
        _pauseMenu.Hide();
        _levelUpScreen.Hide();
        _levelEndScreen.Hide();
    }

    private void OnEnable()
    {
        _levelManager.LevelFailed += OnLevelEnd;
        _levelManager.LevelCompleted += OnLevelCompleted;
    }

    private void OnDisable()
    {
        _levelManager.LevelFailed -= OnLevelEnd;
        _levelManager.LevelCompleted -= OnLevelCompleted;
    }

    private void Start()
    {
        var level = _saveLoadManager.CurrentSaveData.Level;

        _levelManager.StartLevel(level);
    }

    private void OnLevelEnd()
    {
        _levelEndScreen.Show();
    }

    private void OnLevelCompleted()
    {
        var gameData = new GameData
        {
            PlayerLevel = _player.ExperienceManager.CurrentLevel,
            PlayerExperience = _player.ExperienceManager.Experience,
            Level = GameConfig.GetNextLevelAfter(_levelManager.GetCurrentLevel()),
            CharacterStats = _player.StatsController.Stats
        };

        _saveLoadManager.SaveGameData(gameData);

        SceneManager.LoadScene(Scenes.NewGame);
    }
}