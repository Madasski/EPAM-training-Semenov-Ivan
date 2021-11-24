using Composition;
using Core;
using UI;
using UnityEngine;

public class MainMenuSceneStarter : MonoBehaviour
{
    private IUIRoot _uiRoot;
    private IResourceManager _resourceManager;

    private void Awake()
    {
        _uiRoot = CompositionRoot.GetUIRoot();
        _resourceManager = CompositionRoot.GetResourceManager();

        var mainMenuUIPrefab = _resourceManager.GetMainMenuUIPrefab();
        Instantiate(mainMenuUIPrefab, _uiRoot.StaticCanvas);

        // _uiRoot.InstantiateMainMenuUI();
    }
}