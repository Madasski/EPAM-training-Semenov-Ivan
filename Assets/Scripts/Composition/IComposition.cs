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
        CameraFollow GetPlayerCamera();
        PlayerCharacter GetPlayerCharacter();
        IResourceManager GetResourceManager();
    }
}