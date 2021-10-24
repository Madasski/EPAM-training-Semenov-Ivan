using Core;
using UnityEngine;

public class LevelUpScreen : MonoBehaviour, IScreen
{
    public PlayerCharacter PlayerCharacter;

    public void Show()
    {
        PauseManager.Pause();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        PauseManager.Resume();
        gameObject.SetActive(false);
    }

    public void OnPowerLevelUpPress()
    {
        PlayerCharacter.Stats.Power += 50;
        Hide();
    }

    public void OnHealthLevelUpPress()
    {
        PlayerCharacter.Stats.Health += 50;
        Hide();
    }

    public void OnSpeedLevelUpPress()
    {
        PlayerCharacter.Stats.Speed += 50;
        Hide();
    }
}