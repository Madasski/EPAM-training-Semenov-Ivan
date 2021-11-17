using Core;
using UI;
using UnityEngine;

namespace Composition
{
    public class CompositionRoot : MonoBehaviour
    {
        private static IComposition s_composition = new ReleaseComposition();

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
    }
}