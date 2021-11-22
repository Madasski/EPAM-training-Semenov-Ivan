namespace UI
{
    public interface IUIRoot
    {
        void InstantiateMainMenuUI();
        void InstantiateHUD();
        void InstantiateDynamicUI(LevelManager levelManager);
    }
}