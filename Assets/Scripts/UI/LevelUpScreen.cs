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
        PlayerCharacter.Stats.UpgradePower(5);
        Hide();
    }

    public void OnHealthLevelUpPress()
    {
        PlayerCharacter.Stats.UpgradeHealth(50);
        Hide();
    }

    public void OnSpeedLevelUpPress()
    {
        PlayerCharacter.Stats.UpgradeSpeed(50);
        Hide();
    }
}