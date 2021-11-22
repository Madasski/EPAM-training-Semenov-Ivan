using Core;
using Core.Sound;
using UI;
using UnityEngine;

namespace Composition
{
    public class ReleaseComposition : IComposition
    {
        private IUIRoot _uiRoot;
        private CameraFollow _playerCamera;
        private AudioManager _audioManager;
        private PlayerCharacter _playerCharacter;
        private IResourceManager _resourceManager;

        public void Destroy()
        {
            _uiRoot = null;
        }

        public IUIRoot GetUIRoot()
        {
            if (_uiRoot == null)
            {
                _uiRoot = GameObject.Instantiate(GetResourceManager().GetUIRootPrefab());
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

        public CameraFollow GetPlayerCamera()
        {
            if (_playerCamera == null)
            {
                _playerCamera = GameObject.Instantiate(GetResourceManager().GetCameraPrefab());
            }

            return _playerCamera;
        }

        public PlayerCharacter GetPlayerCharacter()
        {
            if (_playerCharacter == null)
            {
                _playerCharacter = GameObject.Instantiate(GetResourceManager().GetPlayerCharacterPrefab());
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
    }
}