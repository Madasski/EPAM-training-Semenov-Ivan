using System;
using UI;
using UnityEngine;

namespace Core
{
    public class ResourceManager : IResourceManager
    {
        public TPrefab GetPrefab<TType, TPrefab>(TType type) where TPrefab : MonoBehaviour
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