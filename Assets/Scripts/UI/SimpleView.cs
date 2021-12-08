using UnityEngine;

public class SimpleView : MonoBehaviour, IView
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent, false);
    }
}