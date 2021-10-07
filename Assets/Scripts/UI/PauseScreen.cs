using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public bool IsPaused;
    
    public void Show()
    {
        IsPaused = true;
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}