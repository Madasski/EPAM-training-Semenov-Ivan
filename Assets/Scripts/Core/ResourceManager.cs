using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core
{
    public class ResourceManager : IResourceManager
    {
        public T CreatePrefabInstance<E, T>(E item) where E : Enum
        {
            var prefab = CreatePrefabInstance(item);
            var result = prefab.GetComponent<T>();

            return result;
        }

        public GameObject CreatePrefabInstance<E>(E item) where E : Enum
        {
            var prefab = GetPrefab(item);
            var result = Object.Instantiate(prefab);

            return result;
        }

        public T GetPrefab<E, T>(E item) where E : Enum
        {
            var prefab = GetPrefab<E>(item);
            var result = prefab.GetComponent<T>();

            return result;
        }

        public GameObject GetPrefab<E>(E item) where E : Enum
        {
            var path = typeof(E).Name + "/" + item.ToString();
            var prefab = Resources.Load<GameObject>(path);

            return prefab;
        }

        //
        // public EnemyHealthBarManager GetHealthBarManager()
        // {
        //     var healthBarManagerPrefab = Resources.Load<EnemyHealthBarManager>("HealthBarManager");
        //     return healthBarManagerPrefab;
        // }
        //
        // public UIRoot GetUIRootPrefab()
        // {
        //     var uiRootPrefab = Resources.Load<UIRoot>("UIRoot");
        //     return uiRootPrefab;
        // }
        //
        // public HUD GetHUDPrefab()
        // {
        //     var hudPrefab = Resources.Load<HUD>("HUD");
        //     return hudPrefab;
        // }
        //
        // public IMainMenu GetMainMenuUIPrefab()
        // {
        //     var mainMenuUIPrefab = Resources.Load<MainMenu>("MainMenuUI");
        //     return mainMenuUIPrefab;
        // }
        //
        // public PlayerCharacter GetPlayerCharacterPrefab()
        // {
        //     var playerPrefab = Resources.Load<PlayerCharacter>("Player");
        //     return playerPrefab;
        // }
        //
        // public CameraFollow GetCameraPrefab()
        // {
        //     var cameraPrefab = Resources.Load<CameraFollow>("Camera");
        //     return cameraPrefab;
        // }
        //
        // public AudioClip GetAudioClip<TType>(TType audioClipType) where TType : Enum
        // {
        //     return null;
        // }
        //
        // public AudioClip GetMusic<TType>(TType musicClip) where TType : Enum
        // {
        //     return null;
        // }
    }
}