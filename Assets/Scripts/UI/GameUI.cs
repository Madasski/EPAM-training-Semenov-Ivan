using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject EndLevelScreen;
    public PauseScreen PauseScreen;
    public GameObject HUD;
    public LevelUpScreen LevelUpScreen;

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
        if (PauseScreen.isActiveAndEnabled)
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

    public void ShowLevelUpScreen()
    {
        LevelUpScreen.Show();
    }

    public void HideLevelUpScreen()
    {
        LevelUpScreen.Hide();
    }
}