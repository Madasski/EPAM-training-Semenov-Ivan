using UnityEngine;

namespace UI
{
    public class SimpleScreen : MonoBehaviour, IScreen
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}