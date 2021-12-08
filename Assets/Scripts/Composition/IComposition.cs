using Core;
using Core.Saving;
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
        ISaveLoadManager GetSaveLoadManager();
        IResourceManager GetResourceManager();

        IHUD GetHUD();
        IMainMenu GetMainMenu();
        IPauseMenu GetPauseMenu();
        ISettingsMenu GetSettingsMenu();
        ILevelUpScreen GetLevelUpScreen();
        ILevelEndScreen GetLevelEndScreen();
        IHealthBarDrawer GetHealthBarDrawer();
    }
}