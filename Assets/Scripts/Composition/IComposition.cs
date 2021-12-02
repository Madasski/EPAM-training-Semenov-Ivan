using Core;
using Core.Sound;
using UI;

namespace Composition
{
    public interface IComposition
    {
        void Destroy();
        IUIRoot GetUIRoot();
        IInput GetUserInput();
        IViewFactory GetViewFactory();
        AudioManager GetAudioManager();
        ILevelManager GetLevelManager();
        ICameraFollow GetPlayerCamera();
        PlayerCharacter GetPlayerCharacter();
        IResourceManager GetResourceManager();

        IHUD GetHUD();
        IMainMenu GetMainMenu();
        IPauseMenu GetPauseMenu();
        ISettingsMenu GetSettingsMenu();
        ILevelEndScreen GetLevelEndScreen();
        IHealthBarDrawer GetHealthBarDrawer();
    }
}