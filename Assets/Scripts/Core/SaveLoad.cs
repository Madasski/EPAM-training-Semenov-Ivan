using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Madasski.Core
{
    public static class SaveLoad
    {
        private static string _savePath = "/GameSave.save";

        public static void SaveGame(GameData gameData)
        {
            var bf = new BinaryFormatter();
            var file = File.Create(_savePath);
            bf.Serialize(file, gameData);
            file.Close();
        }

        public static GameData LoadGame()
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

    public class GameData
    {
        public Stats
    }
}