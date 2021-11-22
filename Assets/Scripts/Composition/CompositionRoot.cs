using Core;
using Core.Sound;
using UI;
using UnityEngine;

namespace Composition
{
    public class CompositionRoot : MonoBehaviour
    {
        private static readonly IComposition s_composition = new ReleaseComposition();

        private void OnDestroy()
        {
            s_composition.Destroy();
        }

        public static IUIRoot GetUIRoot()
        {
            return s_composition.GetUIRoot();
        }

        public static IResourceManager GetResourceManager()
        {
            return s_composition.GetResourceManager();
        }

        public static CameraFollow GetPlayerCamera()
        {
            return s_composition.GetPlayerCamera();
        }

        public static PlayerCharacter GetPlayerCharacter()
        {
            return s_composition.GetPlayerCharacter();
        }

        public static AudioManager GetAudioManager()
        {
            return s_composition.GetAudioManager();
        }
    }
}