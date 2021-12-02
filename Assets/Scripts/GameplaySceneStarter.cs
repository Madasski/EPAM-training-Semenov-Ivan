using Composition;
using Core;
using UnityEngine;

public class GameplaySceneStarter : MonoBehaviour
{
    private ICameraFollow _camera;
    private IPlayerCharacter _player;
    private ILevelManager _levelManager;
    private IResourceManager _resourceManager;
    private IHealthBarDrawer _healthBarDrawer;

    private IHUD _hud;
    private IPauseMenu _pauseMenu;
    private ILevelEndScreen _levelEndScreen;

    private void Awake()
    {
        _camera = CompositionRoot.GetPlayerCamera();
        _player = CompositionRoot.GetPlayerCharacter();
        _levelManager = CompositionRoot.GetLevelManager();
        _resourceManager = CompositionRoot.GetResourceManager();

        _hud = CompositionRoot.GetHUD();
        _pauseMenu = CompositionRoot.GetPauseMenu();
        _levelEndScreen = CompositionRoot.GetLevelEndScreen();
        _healthBarDrawer = CompositionRoot.GetHealthBarDrawer();

        _hud.Show();
        _pauseMenu.Hide();
        _levelEndScreen.Hide();

        _camera.SetTarget(_player.Mover.Transform);
        _hud.SetPlayer(_player);
    }

    private void OnEnable()
    {
        _levelManager.OnLevelEnd += OnLevelEnd;
    }

    private void OnDisable()
    {
        _levelManager.OnLevelEnd -= OnLevelEnd;
    }

    private void Start()
    {
        _levelManager.StartLevel();
    }

    private void OnLevelEnd()
    {
        _levelEndScreen.Show();
    }
}