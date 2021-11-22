using Composition;
using UI;
using UnityEngine;

public class GameplaySceneStarter : MonoBehaviour
{
    private LevelManager _levelManager;

    private IUIRoot _uiRoot;
    // private IResourceManager _resourceManager;

    private void Awake()
    {
        // _resourceManager = CompositionRoot.GetResourceManager();
        _levelManager = new LevelManager();
        _uiRoot = CompositionRoot.GetUIRoot();
        
        SetupCamera();
        SetupUI();
    }

    private void OnEnable()
    {
    }

    private void Start()
    {
        _levelManager.StartLevel();
    }

    private void SetupUI()
    {
        _uiRoot.InstantiateHUD();
        _uiRoot.InstantiateDynamicUI(_levelManager);
    }

    private void SetupCamera()
    {
        var cam = CompositionRoot.GetPlayerCamera();
        cam.SetTarget(CompositionRoot.GetPlayerCharacter().transform);
    }
}