using UI;
using UnityEngine;

namespace Core
{
    public interface IResourceManager
    {
        TPrefab GetPrefab<TType, TPrefab>(TType type) where TPrefab : Object;
        UIRoot GetUIRootPrefab();
        PlayerCharacter GetPlayerCharacterPrefab();
        CameraFollow GetCameraPrefab();
    }
}