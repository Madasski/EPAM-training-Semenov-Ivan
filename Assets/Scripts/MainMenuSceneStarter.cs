using Composition;
using UI;
using UnityEngine;

public class MainMenuSceneStarter : MonoBehaviour
{
    private IUIRoot _uiRoot;

    private void Awake()
    {
        _uiRoot = CompositionRoot.GetUIRoot();
        _uiRoot.InstantiateMainMenuUI();
    }
}