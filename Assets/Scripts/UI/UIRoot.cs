using Composition;
using Core;
using UnityEngine;

namespace UI
{
    public class UIRoot : MonoBehaviour, IUIRoot
    {
        private MainMenuUI _mainMenuUI;
        private IResourceManager _resourceManager;

        private void Awake()
        {
            _resourceManager = CompositionRoot.GetResourceManager();
        }

        public void InstantiateMainMenuUI()
        {
            var mainMenuUIPrefab = _resourceManager.GetPrefab<ECanvases, MainMenuUI>(ECanvases.MainMenuUI);
            _mainMenuUI = Instantiate(mainMenuUIPrefab, transform);
        }
    }

    public enum ECanvases
    {
        MainMenuUI,
        HUD
    }
}