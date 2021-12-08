namespace Core.Saving
{
    public interface ISaveLoadManager
    {
        GameData CurrentSaveData { get; }

        void SaveGameData(GameData gameData);
        GameData LoadGameData();
    }
}