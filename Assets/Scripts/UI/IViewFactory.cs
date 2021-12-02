namespace UI
{
    public interface IViewFactory
    {
        IHUDView CreateHUD();
        IMainMenuView CreateMainMenu();
        IPauseMenuView CreatePauseMenu();
        IHealthBarView CreateHealthBar();
        ISettingsMenuView CreateSettingsMenu();
        ILevelEndScreenView CreateLevelEndScreen();
    }
}