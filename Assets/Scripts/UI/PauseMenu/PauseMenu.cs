using Composition;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour, IPauseMenu
{
    private IPauseMenuView _view;
    private IInput _input;
    private bool _isOn = true;

    private void Awake()
    {
        _input = CompositionRoot.GetUserInput();

        var viewFactory = CompositionRoot.GetViewFactory();
        _view = viewFactory.CreatePauseMenu();
    }

    private void OnEnable()
    {
        _input.PausePressed += Toggle;
        _view.ResumeClicked += OnResumeClicked;
        _view.RestartClicked += OnRestartClicked;
    }

    private void OnDisable()
    {
        _input.PausePressed -= Toggle;
        _view.ResumeClicked -= OnResumeClicked;
        _view.RestartClicked -= OnRestartClicked;
    }

    private void Toggle()
    {
        if (_isOn)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    public void Show()
    {
        PauseManager.Pause();
        _view.Show();
        _isOn = true;
    }

    public void Hide()
    {
        PauseManager.Resume();
        _view.Hide();
        _isOn = false;
    }

    private void OnResumeClicked()
    {
        Hide();
    }

    private void OnRestartClicked()
    {
        Hide();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}