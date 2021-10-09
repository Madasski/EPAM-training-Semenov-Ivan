using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(Scenes.NewGame);
    }
}