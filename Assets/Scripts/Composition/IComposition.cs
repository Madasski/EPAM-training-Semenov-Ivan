using Core;
using Core.Saving;
using Core.Services;
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
        ISkillLibrary GetSkillLibrary();
        AudioManager GetAudioManager();
        ILevelManager GetLevelManager();
        ICameraFollow GetPlayerCamera();
        IPlayerCharacter GetPlayerCharacter();
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