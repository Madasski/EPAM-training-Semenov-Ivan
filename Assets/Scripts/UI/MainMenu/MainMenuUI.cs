using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public string NewGameScene;

    public void NewGame()
    {
        SceneManager.LoadScene(NewGameScene);
    }
}