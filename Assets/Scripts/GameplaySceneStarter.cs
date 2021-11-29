using Composition;
using Core;
using UnityEngine;

public class GameplaySceneStarter : MonoBehaviour
{
    private ICameraFollow _camera;
    private PlayerCharacter _player;
    private ILevelManager _levelManager;
    private IResourceManager _resourceManager;

    private IHUD _hud;
    private IHealthBarDrawer _healthBarDrawer;

    private void Awake()
    {
        _resourceManager = CompositionRoot.GetResourceManager();
        _levelManager = CompositionRoot.GetLevelManager();
        _camera = CompositionRoot.GetPlayerCamera();
        _player = CompositionRoot.GetPlayerCharacter();

        _camera.SetTarget(_player.transform);

        _hud = CompositionRoot.GetHUD();
        _hud.SetPlayer(_player);

        _healthBarDrawer = CompositionRoot.GetHealthBarDrawer();

        // var healthBarManagerPrefab = _resourceManager.GetHealthBarManager();
        // Instantiate(healthBarManagerPrefab, _uiRoot.DynamicCanvas);
    }

    private void Start()
    {
        _levelManager.StartLevel();
    }
}