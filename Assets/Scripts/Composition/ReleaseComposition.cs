using Core;
using Core.Saving;
using Core.Services;
using Core.Sound;
using UI;
using UnityEngine;

namespace Composition
{
    public class ReleaseComposition : IComposition
    {
        private IInput _input;
        private IUIRoot _uiRoot;
        private ViewFactory _viewFactory;
        private ISkillLibrary _skillLibrary;
        private LevelManager _levelManager;
        private ICameraFollow _playerCamera;
        private AudioManager _audioManager;
        private PlayerCharacter _playerCharacter;
        private ISaveLoadManager _saveLoadManager;
        private IResourceManager _resourceManager;

        private IHUD _hud;
        private IMainMenu _mainMenu;
        private IPauseMenu _pauseMenu;
        private ISettingsMenu _settingsMenu;
        private ILevelUpScreen _levelUpScreen;
        private ILevelEndScreen _levelEndScreen;
        private IHealthBarDrawer _healthBarDrawer;

        public void Destroy()
        {
            _input = null;
            _uiRoot = null;
            _viewFactory = null;
            _playerCamera = null;
            _audioManager = null;
            _levelManager = null;

            _hud = null;
            _mainMenu = null;
            _pauseMenu = null;
            _settingsMenu = null;
            _levelUpScreen = null;
            _levelEndScreen = null;
            _healthBarDrawer = null;
        }

        public IHUD GetHUD()
        {
            if (_hud == null)
            {
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
                var go = new GameObject("MainMenu");
                var result = go.AddComponent<MainMenu>();
                _mainMenu = result;
            }

            return _mainMenu;
        }

        public IPauseMenu GetPauseMenu()
        {
            if (_pauseMenu == null)
            {
                var go = new GameObject("PauseMenu");
                var result = go.AddComponent<PauseMenu>();
                _pauseMenu = result;
            }

            return _pauseMenu;
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

        public ILevelUpScreen GetLevelUpScreen()
        {
            if (_levelUpScreen == null)
            {
                var go = new GameObject("LevelUpScreen");
                var result = go.AddComponent<LevelUpScreen>();
                _levelUpScreen = result;
            }

            return _levelUpScreen;
        }

        public ILevelEndScreen GetLevelEndScreen()
        {
            if (_levelEndScreen == null)
            {
                var go = new GameObject("LevelEndScreen");
                var result = go.AddComponent<LevelEndScreen>();
                _levelEndScreen = result;
            }

            return _levelEndScreen;
        }

        public IHealthBarDrawer GetHealthBarDrawer()
        {
            if (_healthBarDrawer == null)
            {
                var go = new GameObject("HealthBarDrawer");
                var result = go.AddComponent<HealthBarDrawer>();
                _healthBarDrawer = result;
            }

            return _healthBarDrawer;
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

        public IInput GetUserInput()
        {
            if (_input == null)
            {
                var go = new GameObject("UserInput");
                var result = go.AddComponent<PlayerInput>();
                _input = result;
            }

            return _input;
        }

        public ISkillLibrary GetSkillLibrary()
        {
            if (_skillLibrary == null)
            {
                var resourceManager = GetResourceManager();

                _skillLibrary = resourceManager.CreatePrefabInstance<EComponents, SkillLibrary>(EComponents.SkillLibrary);
            }

            return _skillLibrary;
            
        }

        public AudioManager GetAudioManager()
        {
            if (_audioManager == null)
            {
                _audioManager = new GameObject("AudioManager").AddComponent<AudioManager>();
            }

            return _audioManager;
        }

        public ILevelManager GetLevelManager()
        {
            if (_levelManager == null)
            {
                _levelManager = new GameObject("LevelManager").AddComponent<LevelManager>();
            }

            return _levelManager;
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

        public IPlayerCharacter GetPlayerCharacter()
        {
            if (_playerCharacter == null)
            {
                var resourceManager = GetResourceManager();
                _playerCharacter = resourceManager.CreatePrefabInstance<EComponents, PlayerCharacter>(EComponents.Player);
            }

            return _playerCharacter;
        }

        public ISaveLoadManager GetSaveLoadManager()
        {
            if (_saveLoadManager == null)
            {
                _saveLoadManager = new SaveLoadManager();
            }

            return _saveLoadManager;
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