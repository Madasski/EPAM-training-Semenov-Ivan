using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndScreenView : SimpleView, ILevelEndScreenView
{
    public event Action RestartClicked;
    public event Action GoToMenuClicked;

    [SerializeField] private Button _goToMenuButton;
    [SerializeField] private Button _restartLevelButton;

    private void OnEnable()
    {
        _goToMenuButton.onClick.AddListener(OnGoToMenuClick);
        _restartLevelButton.onClick.AddListener(OnRestartClicked);
    }

    private void OnGoToMenuClick()
    {
        GoToMenuClicked.Invoke();
    }

    private void OnRestartClicked()
    {
        RestartClicked.Invoke();
    }
}