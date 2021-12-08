using Composition;
using Core;
using UnityEngine;

public class LevelUpScreen : MonoBehaviour, ILevelUpScreen
{
    private ILevelUpScreenView _view;
    private IPlayerCharacter _playerCharacter;
    private IExperienceManager _experienceManager;

    private void Awake()
    {
        var viewFactory = CompositionRoot.GetViewFactory();
        _view = viewFactory.CreateLevelUpScreen();

        _playerCharacter = CompositionRoot.GetPlayerCharacter();
        _experienceManager = _playerCharacter.ExperienceManager;
    }

    private void OnEnable()
    {
        _view.HealthClicked += OnHealthLevelUpPress;
        _view.PowerClicked += OnPowerLevelUpPress;
        _view.SpeedClicked += OnSpeedLevelUpPress;

        _experienceManager.LevelGained += OnLevelGained;
    }

    private void OnDisable()
    {
        _view.HealthClicked -= OnHealthLevelUpPress;
        _view.PowerClicked -= OnPowerLevelUpPress;
        _view.SpeedClicked -= OnSpeedLevelUpPress;

        _experienceManager.LevelGained -= OnLevelGained;
    }

    public void Show()
    {
        PauseManager.Pause();
        _view.Show();
    }

    public void Hide()
    {
        PauseManager.Resume();
        _view.Hide();
    }

    private void OnLevelGained(int level)
    {
        Show();
    }

    private void OnPowerLevelUpPress()
    {
        _playerCharacter.StatsController.Power += 50;
        Hide();
    }

    private void OnHealthLevelUpPress()
    {
        _playerCharacter.StatsController.Health += 50;
        Hide();
    }

    private void OnSpeedLevelUpPress()
    {
        _playerCharacter.StatsController.Speed += 50;
        Hide();
    }
}