using Core;
using UnityEngine;

public class PauseScreen : MonoBehaviour, IScreen
{
    public void Show()
    {
        PauseManager.Pause();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        PauseManager.Resume();
        gameObject.SetActive(false);
    }
}