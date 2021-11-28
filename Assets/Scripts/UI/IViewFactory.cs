namespace UI
{
    public interface IViewFactory
    {
        IMainMenuView CreateMainMenu();
        ISettingsMenuView CreateSettingsMenu();
        // IGameHUDView CreateGameHUD();
    }
}