using UnityEngine;

namespace UI
{
    public class UIRoot : MonoBehaviour, IUIRoot
    {
        [SerializeField] private RectTransform _dynamicCanvas;
        [SerializeField] private RectTransform _staticCanvas;

        public RectTransform DynamicCanvas => _dynamicCanvas;
        public RectTransform StaticCanvas => _staticCanvas;
    }
}