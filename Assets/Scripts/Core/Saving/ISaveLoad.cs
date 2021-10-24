using UnityEngine;

namespace Core.Saving
{
    public interface ISaveLoad
    {
        void Save(GameData gameData);
        void Load(GameData gameData);
    }
}