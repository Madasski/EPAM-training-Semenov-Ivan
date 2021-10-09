using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject EndLevelScreen;
    public PauseScreen PauseScreen;
    public GameObject HUD;

    public void ShowLevelEndScreen()
    {
        EndLevelScreen.SetActive(true);
    }

    public void HideLevelEndScreen()
    {
        EndLevelScreen.SetActive(false);
    }

    public void TogglePauseScreen()
    {
        if (PauseScreen.IsPaused)
        {
            HidePauseScreen();
        }
        else
        {
            ShowPauseScreen();
        }
    }

    public void ShowPauseScreen()
    {
        PauseScreen.Show();
    }

    public void HidePauseScreen()
    {
        PauseScreen.Hide();
    }
}