using UI;
using UnityEngine;

namespace Core
{
    public interface IResourceManager
    {
        UIRoot GetUIRootPrefab();
        CameraFollow GetCameraPrefab();
        MainMenuUI GetMainMenuUIPrefab();
        HUD GetHUDPrefab();
        PlayerCharacter GetPlayerCharacterPrefab();
        TPrefab GetPrefab<TType, TPrefab>(TType type) where TPrefab : Object;
    }
}