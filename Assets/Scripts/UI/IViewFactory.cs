namespace UI
{
    public interface IViewFactory
    {
        IHUDView CreateHUD();
        IMainMenuView CreateMainMenu();
        IHealthBarView CreateHealthBar();
        ISettingsMenuView CreateSettingsMenu();
    }
}