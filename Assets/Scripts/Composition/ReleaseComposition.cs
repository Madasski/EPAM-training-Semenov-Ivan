using Core;
using Core.Sound;
using UI;
using UnityEngine;

namespace Composition
{
    public class ReleaseComposition : IComposition
    {
        private IUIRoot _uiRoot;
        private ViewFactory _viewFactory;
        private ICameraFollow _playerCamera;
        private AudioManager _audioManager;
        private PlayerCharacter _playerCharacter;
        private IResourceManager _resourceManager;

        private IHUD _hud;
        private IMainMenu _mainMenu;
        private ISettingsMenu _settingsMenu;

        public void Destroy()
        {
            _uiRoot = null;
        }

        public IHUD GetHUD()
        {
            if (_hud == null)
            {
                // _mainMenu = new MainMenu();
                var go = new GameObject("HUD");
                var result = go.AddComponent<HUD>();
                _hud = result;
            }

            return _hud;
        }

        public IMainMenu GetMainMenu()
        {
            if (_mainMenu == null)
            {
                // _mainMenu = new MainMenu();
                var go = new GameObject("MainMenu");
                var result = go.AddComponent<MainMenu>();
                _mainMenu = result;
            }

            return _mainMenu;
        }

        public ISettingsMenu GetSettingsMenu()
        {
            if (_settingsMenu == null)
            {
                var go = new GameObject("SettingsMenu");
                var result = go.AddComponent<SettingsMenu>();
                _settingsMenu = result;
            }

            return _settingsMenu;
        }

        public IUIRoot GetUIRoot()
        {
            if (_uiRoot == null)
            {
                var resourceManager = GetResourceManager();

                _uiRoot = resourceManager.CreatePrefabInstance<EComponents, IUIRoot>(EComponents.UIRoot);
            }

            return _uiRoot;
        }

        public AudioManager GetAudioManager()
        {
            if (_audioManager == null)
            {
                _audioManager = new GameObject("AudioManager").AddComponent<AudioManager>();
            }

            return _audioManager;
        }

        public ICameraFollow GetPlayerCamera()
        {
            if (_playerCamera == null)
            {
                var resourceManager = GetResourceManager();
                _playerCamera = resourceManager.CreatePrefabInstance<EComponents, ICameraFollow>(EComponents.PlayerCamera);
            }

            return _playerCamera;
        }

        public PlayerCharacter GetPlayerCharacter()
        {
            if (_playerCharacter == null)
            {
                var resourceManager = GetResourceManager();
                _playerCharacter = resourceManager.CreatePrefabInstance<EComponents, PlayerCharacter>(EComponents.Player);
            }

            return _playerCharacter;
        }

        public IResourceManager GetResourceManager()
        {
            if (_resourceManager == null)
            {
                _resourceManager = new ResourceManager();
            }

            return _resourceManager;
        }

        public IViewFactory GetViewFactory()
        {
            if (_viewFactory == null)
            {
                var uiRoot = GetUIRoot();
                var resourceManager = GetResourceManager();

                _viewFactory = new ViewFactory(uiRoot, resourceManager);
            }

            return _viewFactory;
        }
    }
}