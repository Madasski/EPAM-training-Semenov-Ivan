using Core;

namespace UI
{
    public class ViewFactory : IViewFactory
    {
        private IUIRoot _uiRoot;
        private IResourceManager _resourceManager;

        public ViewFactory(IUIRoot uiRoot, IResourceManager resourceManager)
        {
            _uiRoot = uiRoot;
            _resourceManager = resourceManager;
        }

        public IHUDView CreateHUD()
        {
            var view = _resourceManager.CreatePrefabInstance<EViews, IHUDView>(EViews.HUD);
            view.SetParent(_uiRoot.StaticCanvas);

            return view;
        }

        public IMainMenuView CreateMainMenu()
        {
            var view = _resourceManager.CreatePrefabInstance<EViews, IMainMenuView>(EViews.MainMenu);
            view.SetParent(_uiRoot.StaticCanvas);

            return view;
        }

        public IHealthBarView CreateHealthBar()
        {
            var view = _resourceManager.CreatePrefabInstance<EWidgets, IHealthBarView>(EWidgets.HealthBar);
            view.SetParent(_uiRoot.DynamicCanvas);

            return view;
        }

        public ISettingsMenuView CreateSettingsMenu()
        {
            var view = _resourceManager.CreatePrefabInstance<EViews, ISettingsMenuView>(EViews.SettingsMenu);
            view.SetParent(_uiRoot.StaticCanvas);

            return view;
        }
    }
}