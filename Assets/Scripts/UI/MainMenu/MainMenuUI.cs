using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(Scenes.NewGame);
    }
}