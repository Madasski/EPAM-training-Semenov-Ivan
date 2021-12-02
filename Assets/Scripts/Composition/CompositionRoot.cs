using Core;
using Core.Sound;
using UI;
using UnityEngine;

namespace Composition
{
    public class CompositionRoot : MonoBehaviour
    {
        private static readonly IComposition s_composition = new ReleaseComposition();
        // private static readonly IComposition s_composition = new ReleaseComposition();

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

        public static ICameraFollow GetPlayerCamera()
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

        public static IViewFactory GetViewFactory()
        {
            return s_composition.GetViewFactory();
        }

        public static IMainMenu GetMainMenu()
        {
            return s_composition.GetMainMenu();
        }

        public static ISettingsMenu GetSettingsMenu()
        {
            return s_composition.GetSettingsMenu();
        }

        public static IHUD GetHUD()
        {
            return s_composition.GetHUD();
        }

        public static ILevelManager GetLevelManager()
        {
            return s_composition.GetLevelManager();
        }

        public static IHealthBarDrawer GetHealthBarDrawer()
        {
            return s_composition.GetHealthBarDrawer();
        }

        public static IPauseMenu GetPauseMenu()
        {
            return s_composition.GetPauseMenu();
        }

        public static IInput GetUserInput()
        {
            return s_composition.GetUserInput();
        }

        public static ILevelEndScreen GetLevelEndScreen()
        {
            return s_composition.GetLevelEndScreen();
        }
    }
}