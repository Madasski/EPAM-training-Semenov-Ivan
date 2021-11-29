namespace UI
{
    public interface IViewFactory
    {
        IHUDView CreateHUD();
        IMainMenuView CreateMainMenu();
        IHealthBarView CreateHealthBarView();
        ISettingsMenuView CreateSettingsMenu();
        // IGameHUDView CreateGameHUD();
    }
}