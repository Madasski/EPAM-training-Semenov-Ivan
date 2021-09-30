using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public String NewGameScene;

    public void NewGame()
    {
        SceneManager.LoadScene(NewGameScene);
    }
}