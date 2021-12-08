using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : SimpleView, IMainMenuView
{
    public event Action NewGameClicked = () => { };
    public event Action LoadGameClicked = () => { };
    public event Action SettingsClicked = () => { };
    public event Action ExitClicked = () => { };

    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _loadGameButton;
    [SerializeField] private Button _settingsButton;

    private void OnEnable()
    {
        _newGameButton.onClick.AddListener(OnNewGameClicked);
        _loadGameButton.onClick.AddListener(OnLoadGameClicked);
        _settingsButton.onClick.AddListener(OnSettingsClicked);
    }

    private void OnDisable()
    {
        _newGameButton.onClick.RemoveListener(OnNewGameClicked);
        _loadGameButton.onClick.RemoveListener(OnLoadGameClicked);
        _settingsButton.onClick.RemoveListener(OnSettingsClicked);
    }

    private void OnNewGameClicked()
    {
        NewGameClicked();
    }

    private void OnLoadGameClicked()
    {
        LoadGameClicked();
    }

    private void OnSettingsClicked()
    {
        SettingsClicked();
    }

    private void OnExitClicked()
    {
        ExitClicked();
    }
}