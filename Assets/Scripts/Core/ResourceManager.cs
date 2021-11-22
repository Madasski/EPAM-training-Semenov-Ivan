using System;
using UI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core
{
    public class ResourceManager : IResourceManager
    {
        public TPrefab GetPrefab<TType, TPrefab>(TType type) where TPrefab : Object
        {
            var path = typeof(TType).Name + "/" + type.ToString();
            // Debug.Log(path);
            var prefab = Resources.Load<TPrefab>(path);

            return prefab;
        }

        public UIRoot GetUIRootPrefab()
        {
            var uiRootPrefab = Resources.Load<UIRoot>("UIRoot");
            return uiRootPrefab;
        }

        public PlayerCharacter GetPlayerCharacterPrefab()
        {
            var playerPrefab = Resources.Load<PlayerCharacter>("Player");
            return playerPrefab;
        }

        public CameraFollow GetCameraPrefab()
        {
            var cameraPrefab = Resources.Load<CameraFollow>("Camera");
            return cameraPrefab;
        }

        public AudioClip GetAudioClip<TType>(TType audioClipType) where TType : Enum
        {
            return null;
        }

        public AudioClip GetMusic<TType>(TType musicClip) where TType : Enum
        {
            return null;
        }
    }
}