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
        _levelManager = new LevelManager();
        _camera = CompositionRoot.GetPlayerCamera();
        _player = CompositionRoot.GetPlayerCharacter();

        _camera.SetTarget(_player.transform);

        _hud = CompositionRoot.GetHUD();
        _hud.SetPlayer(_player);

        _healthBarDrawer = new HealthBarDrawer();

        // var healthBarManagerPrefab = _resourceManager.GetHealthBarManager();
        // Instantiate(healthBarManagerPrefab, _uiRoot.DynamicCanvas);
    }

    private void OnEnable()
    {
        _levelManager.EnemySpawned += character => _healthBarDrawer.DrawHealthBar(character.Health);
        _levelManager.EnemyDied += character => _healthBarDrawer.RemoveHealthBar(character.Health);
    }

    private void OnDisable()
    {
        _levelManager.EnemySpawned -= character => _healthBarDrawer.DrawHealthBar(character.Health);
        _levelManager.EnemyDied -= character => _healthBarDrawer.RemoveHealthBar(character.Health);
    }

    private void Start()
    {
        _levelManager.StartLevel();
    }
}