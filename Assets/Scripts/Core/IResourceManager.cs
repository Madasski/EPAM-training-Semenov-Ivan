using System;
using UnityEngine;

namespace Core
{
    public interface IResourceManager
    {
        T CreatePrefabInstance<E, T>(E item) where E : Enum;
        GameObject CreatePrefabInstance<E>(E item) where E : Enum;

        T GetPrefab<E, T>(E item) where E : Enum;
        GameObject GetPrefab<E>(E item) where E : Enum;
    }
}