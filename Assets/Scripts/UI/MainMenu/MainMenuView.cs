using System;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuView : SimpleView, IMainMenuView
{
    public event Action NewGameClicked = () => { };
    public event Action SettingsClicked = () => { };
    public event Action ExitClicked = () => { };

    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _settingsButton;

    private void OnEnable()
    {
        _newGameButton.onClick.AddListener(OnNewGameClicked);
        _settingsButton.onClick.AddListener(OnSettingsClicked);
    }

    private void OnDisable()
    {
        _newGameButton.onClick.RemoveListener(OnNewGameClicked);
        _settingsButton.onClick.RemoveListener(OnSettingsClicked);
    }

    private void OnNewGameClicked()
    {
        NewGameClicked();
    }

    private void OnSettingsClicked()
    {
        SettingsClicked();
    }

    private void OnExitClicked()
    {
        // ExitClicked();
    }

    // private void NewGame()
    // {
    //     SceneManager.LoadScene(Scenes.NewGame);
    // }
    //
    // private void OnSettingsButtonClick()
    // {
    //     SettingsButtonClicked?.Invoke();
    // }
}