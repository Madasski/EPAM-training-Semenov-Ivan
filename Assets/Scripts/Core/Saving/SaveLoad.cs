using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Madasski.Stats;
using UnityEngine;

namespace Core.Saving
{
    public static class SaveLoad
    {
        private static string _savePath = Application.dataPath + "/GameSave.save";

        public static void SaveGameData(GameData gameData)
        {
            var bf = new BinaryFormatter();
            var file = File.Create(_savePath);
            bf.Serialize(file, gameData);
            file.Close();
        }

        public static GameData LoadGameData()
        {
            GameData gameData = new GameData();
            if (File.Exists(_savePath))
            {
                var bf = new BinaryFormatter();
                var file = File.Open(_savePath, FileMode.Open);
                gameData = (GameData) bf.Deserialize(file);
                file.Close();
            }

            return gameData;
        }
    }

    [Serializable]
    public class GameData
    {
        public CharacterStats CharacterStats = GameConfig.InitialPlayerStats;
        public int PlayerExperience = 0;
    }
}