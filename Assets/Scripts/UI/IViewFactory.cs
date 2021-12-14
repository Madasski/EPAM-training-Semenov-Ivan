namespace UI
{
    public interface IViewFactory
    {
        IHUDView CreateHUD();
        IMainMenuView CreateMainMenu();
        ObjectiveView CreateObjective();
        IPauseMenuView CreatePauseMenu();
        IHealthBarView CreateHealthBar();
        ISettingsMenuView CreateSettingsMenu();
        ILevelUpScreenView CreateLevelUpScreen();
        ILevelEndScreenView CreateLevelEndScreen();
    }
}