using System;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : SimpleScreen
{
    public event Action BackToMenuButtonPressed;

    public Toggle BloodToggle;

    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private Button _applyButton;

    private void OnEnable()
    {
        _backToMenuButton.onClick.AddListener(OnBackToMenuButtonClicked);
        _applyButton.onClick.AddListener(Apply);
    }

    private void OnDisable()
    {
        _backToMenuButton.onClick.RemoveListener(OnBackToMenuButtonClicked);
        _applyButton.onClick.RemoveListener(Apply);
    }

    private void OnBackToMenuButtonClicked()
    {
        BackToMenuButtonPressed?.Invoke();
    }

    public void Apply()
    {
        Settings.ShowBlood = BloodToggle.isOn;
    }
}