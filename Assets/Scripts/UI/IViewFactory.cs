namespace UI
{
    public interface IViewFactory
    {
        IHUDView CreateHUD();
        IMainMenuView CreateMainMenu();
        ISettingsMenuView CreateSettingsMenu();
        // IGameHUDView CreateGameHUD();
    }
}