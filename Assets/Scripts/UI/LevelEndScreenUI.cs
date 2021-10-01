using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndScreenUI : MonoBehaviour
{
    public string MenuSceneName;

    public void GoToMenu()
    {
        SceneManager.LoadScene(MenuSceneName);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}