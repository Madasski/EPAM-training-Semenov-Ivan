using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpScreenView : SimpleView, ILevelUpScreenView
{
    public event Action SpeedClicked;
    public event Action HealthClicked;
    public event Action PowerClicked;

    [SerializeField] private Button _speedButton;
    [SerializeField] private Button _healthButton;
    [SerializeField] private Button _powerButton;

    private void OnEnable()
    {
        _speedButton.onClick.AddListener(OnSpeedClicked);
        _healthButton.onClick.AddListener(OnHealthClicked);
        _powerButton.onClick.AddListener(OnPowerClicked);
    }

    private void OnDisable()
    {
        _speedButton.onClick.RemoveListener(OnSpeedClicked);
        _healthButton.onClick.RemoveListener(OnHealthClicked);
        _powerButton.onClick.RemoveListener(OnPowerClicked);
    }

    private void OnSpeedClicked()
    {
        SpeedClicked.Invoke();
    }

    private void OnHealthClicked()
    {
        HealthClicked.Invoke();
    }

    private void OnPowerClicked()
    {
        PowerClicked.Invoke();
    }
}