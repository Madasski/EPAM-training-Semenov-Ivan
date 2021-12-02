using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuView : SimpleView, IPauseMenuView
{
    public event Action ResumeClicked;
    public event Action RestartClicked;
    public event Action SettingsClicked;

    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _settingsButton;

    private void OnEnable()
    {
        _resumeButton.onClick.AddListener(OnResumeClicked);
        _restartButton.onClick.AddListener(OnRestartClicked);
    }

    private void OnDisable()
    {
        _resumeButton.onClick.RemoveListener(OnResumeClicked);
        _restartButton.onClick.RemoveListener(OnRestartClicked);
    }

    private void OnResumeClicked()
    {
        ResumeClicked.Invoke();
    }

    private void OnRestartClicked()
    {
        RestartClicked.Invoke();
    }
}