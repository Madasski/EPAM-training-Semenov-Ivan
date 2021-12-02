using UnityEngine;
using UnityEngine.Serialization;

public class GameUI : MonoBehaviour
{
    public GameObject EndLevelScreen;
    [FormerlySerializedAs("PauseScreen")] public PauseMenu pauseMenu;
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
        if (pauseMenu.isActiveAndEnabled)
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
        pauseMenu.Show();
    }

    public void HidePauseScreen()
    {
        pauseMenu.Hide();
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