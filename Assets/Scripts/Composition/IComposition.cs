using Core;
using Core.Sound;
using UI;

namespace Composition
{
    public interface IComposition
    {
        void Destroy();
        IUIRoot GetUIRoot();
        AudioManager GetAudioManager();
        ICameraFollow GetPlayerCamera();
        PlayerCharacter GetPlayerCharacter();
        IResourceManager GetResourceManager();
        IViewFactory GetViewFactory();

        IHUD GetHUD();
        IMainMenu GetMainMenu();
        ISettingsMenu GetSettingsMenu();
    }
}