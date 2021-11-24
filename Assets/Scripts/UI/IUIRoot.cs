using UnityEngine;

namespace UI
{
    public interface IUIRoot
    {
        public RectTransform DynamicCanvas { get; }
        public RectTransform StaticCanvas { get; }
    }
}