using Composition;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndScreen : MonoBehaviour, ILevelEndScreen
{
    private ILevelEndScreenView _view;

    private void Awake()
    {
        var viewFactor = CompositionRoot.GetViewFactory();
        _view = viewFactor.CreateLevelEndScreen();
    }

    private void OnEnable()
    {
        _view.RestartClicked += RestartLevel;
        _view.GoToMenuClicked += GoToMenu;
    }

    private void OnDisable()
    {
        _view.RestartClicked -= RestartLevel;
        _view.GoToMenuClicked -= GoToMenu;
    }

    public void Show()
    {
        _view.Show();
    }

    public void Hide()
    {
        _view.Hide();
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene(Scenes.MainMenu);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}