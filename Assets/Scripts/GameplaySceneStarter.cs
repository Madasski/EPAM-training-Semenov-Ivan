using Composition;
using Core;
using UI;
using UnityEngine;

public class GameplaySceneStarter : MonoBehaviour
{
    private LevelManager _levelManager;

    private IUIRoot _uiRoot;
    private IResourceManager _resourceManager;
    private CameraFollow _camera;
    private PlayerCharacter _player;

    private void Awake()
    {
        _resourceManager = CompositionRoot.GetResourceManager();
        _levelManager = new LevelManager();
        _camera = CompositionRoot.GetPlayerCamera();
        _uiRoot = CompositionRoot.GetUIRoot();
        _player = CompositionRoot.GetPlayerCharacter();

        _camera.SetTarget(_player.transform);

        var hudPrefab = _resourceManager.GetHUDPrefab();
        Instantiate(hudPrefab, _uiRoot.StaticCanvas);
        
        // var healthBarMan
    }

    private void Start()
    {
        _levelManager.StartLevel();
    }
}