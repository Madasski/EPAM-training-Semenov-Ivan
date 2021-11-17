using System;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreen : SimpleScreen
{
    public event Action SettingsButtonClicked;

    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _settingsButton;

    private void OnEnable()
    {
        _newGameButton.onClick.AddListener(NewGame);
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);
    }

    private void OnDisable()
    {
        _newGameButton.onClick.RemoveListener(NewGame);
        _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
    }

    private void NewGame()
    {
        SceneManager.LoadScene(Scenes.NewGame);
    }

    private void OnSettingsButtonClick()
    {
        SettingsButtonClicked?.Invoke();
    }
}