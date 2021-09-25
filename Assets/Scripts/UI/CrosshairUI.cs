using UnityEngine;

namespace UI
{
    public class CrosshairUI : MonoBehaviour
    {
        private RectTransform _crosshair;

        private void Awake()
        {
            _crosshair = GetComponent<RectTransform>();
            Cursor.visible = false;
        }

        private void Update()
        {
            _crosshair.position = Input.mousePosition;
        }
    }
}