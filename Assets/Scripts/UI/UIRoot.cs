using Composition;
using Core;
using UnityEngine;

namespace UI
{
    public class UIRoot : MonoBehaviour, IUIRoot
    {
        private HUD _hud;
        private MainMenuUI _mainMenuUI;
        private DynamicUI _dynamicUI;
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

        public void InstantiateHUD()
        {
            var hudPrefab = _resourceManager.GetPrefab<ECanvases, HUD>(ECanvases.HUD);
            _hud = Instantiate(hudPrefab, transform);
        }

        public void InstantiateDynamicUI(LevelManager levelManager)
        {
            var dynamicUIPrefab = _resourceManager.GetPrefab<ECanvases, DynamicUI>(ECanvases.DynamicUI);
            _dynamicUI = Instantiate(dynamicUIPrefab, transform);
            _dynamicUI.EnemyHealthBarManager.Init(levelManager);
        }
    }
}