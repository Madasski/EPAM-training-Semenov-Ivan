using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Madasski.Stats;
using UnityEngine;

namespace Core.Saving
{
    public class SaveLoadManager : ISaveLoadManager
    {
        private static string _savePath = Application.dataPath + "/GameSave.save";
        private GameData _currentGameData = new GameData();

        public GameData CurrentSaveData => _currentGameData;

        public void SaveGameData(GameData gameData)
        {
            var bf = new BinaryFormatter();
            var file = File.Create(_savePath);
            bf.Serialize(file, gameData);
            file.Close();
        }

        public GameData LoadGameData()
        {
            var gameData = new GameData();
            if (!File.Exists(_savePath))
            {
                return gameData;
            }

            var bf = new BinaryFormatter();
            var file = File.Open(_savePath, FileMode.Open);
            gameData = (GameData) bf.Deserialize(file);
            file.Close();

            _currentGameData = gameData;

            return gameData;
        }
    }

    [Serializable]
    public class GameData
    {
        public CharacterStats CharacterStats = GameConfig.InitialPlayerStats;
        public int PlayerExperience = 0;
        public int PlayerLevel = 1;
        public ELevels Level = ELevels.Level01;
    }
}