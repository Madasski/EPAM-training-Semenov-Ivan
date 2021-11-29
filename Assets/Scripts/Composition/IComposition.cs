using Core;
using Core.Sound;
using UI;

namespace Composition
{
    public interface IComposition
    {
        void Destroy();
        IUIRoot GetUIRoot();
        IViewFactory GetViewFactory();
        AudioManager GetAudioManager();
        ILevelManager GetLevelManager();
        ICameraFollow GetPlayerCamera();
        PlayerCharacter GetPlayerCharacter();
        IResourceManager GetResourceManager();

        IHUD GetHUD();
        IMainMenu GetMainMenu();
        ISettingsMenu GetSettingsMenu();
        IHealthBarDrawer GetHealthBarDrawer();
    }
}