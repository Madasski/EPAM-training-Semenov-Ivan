using Core;
using UI;
using UnityEngine;

namespace Composition
{
    public class ReleaseComposition : IComposition
    {
        private IUIRoot _uiRoot;
        private IResourceManager _resourceManager;

        public void Destroy()
        {
            _uiRoot = null;
        }

        public IUIRoot GetUIRoot()
        {
            if (_uiRoot == null)
            {
                _uiRoot = GameObject.Instantiate(GetResourceManager().GetUIRootPrefab());
            }

            return _uiRoot;
        }

        public IResourceManager GetResourceManager()
        {
            if (_resourceManager == null)
            {
                _resourceManager = new ResourceManager();
            }

            return _resourceManager;
        }
    }
}