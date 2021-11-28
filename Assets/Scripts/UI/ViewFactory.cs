﻿using Core;

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

        public IMainMenuView CreateMainMenu()
        {
            var view = _resourceManager.CreatePrefabInstance<EViews, IMainMenuView>(EViews.MainMenu);
            view.SetParent(_uiRoot.StaticCanvas);

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