using Composition;
using Game.Weapons;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public AmmoDisplayUI AmmoDisplayUI;
    public HealthDisplayUI HealthDisplayUI;
    public StatDisplay StatDisplay;

    private PlayerCharacter _playerCharacter;

    private void Awake()
    {
        _playerCharacter = CompositionRoot.GetPlayerCharacter();
    }

    private void OnEnable()
    {
        if (_playerCharacter)
        {
            SubscribeToPlayerChanges();
        }
    }


    private void OnDisable()
    {
        if (_playerCharacter)
        {
            UnsubscribeFromPlayerChanges();
        }
    }

    private void SubscribeToPlayerChanges()
    {
        _playerCharacter.WeaponManager.WeaponChanged += ChangedWeapon;
        _playerCharacter.WeaponManager.OnAmmoLeftChange += OnChangeAmmoLeft;
        _playerCharacter.Health.OnHealthChange += OnPlayerHealthChange;
        _playerCharacter.ExperienceManager.LevelGained += OnPlayerLevelGained;
        _playerCharacter.Stats.SpeedUpdated += OnPlayerSpeedUpdated;
        _playerCharacter.Stats.PowerUpdated += OnPlayerPowerUpdated;
    }

    private void UnsubscribeFromPlayerChanges()
    {
        _playerCharacter.WeaponManager.WeaponChanged -= ChangedWeapon;
        _playerCharacter.WeaponManager.OnAmmoLeftChange -= OnChangeAmmoLeft;
        _playerCharacter.Health.OnHealthChange -= OnPlayerHealthChange;
        _playerCharacter.ExperienceManager.LevelGained -= OnPlayerLevelGained;
        _playerCharacter.Stats.SpeedUpdated -= OnPlayerSpeedUpdated;
        _playerCharacter.Stats.PowerUpdated -= OnPlayerPowerUpdated;
    }

    private void OnPlayerSpeedUpdated(int newAmount)
    {
        StatDisplay.UpdateSpeed(newAmount);
    }

    private void OnPlayerPowerUpdated(int newAmount)
    {
        StatDisplay.UpdatePower(newAmount);
    }

    private void OnPlayerLevelGained()
    {
        StatDisplay.IncreaseLevel();
    }

    private void ChangedWeapon(Weapon newWeapon)
    {
        AmmoDisplayUI.WeaponIcon.sprite = newWeapon.Icon;

        if (newWeapon is Firearm firearm)
        {
            AmmoDisplayUI.UpdateAmmoCounter(firearm.AmmoLeft, firearm.MagazineSize);
        }
        else
        {
            AmmoDisplayUI.UpdateAmmoCounter(-1, -1);
        }
    }

    private void OnChangeAmmoLeft(int ammoLeft)
    {
        AmmoDisplayUI.UpdateAmmoCounter(ammoLeft);
    }

    private void OnPlayerHealthChange(float newHealth, float maxHealth)
    {
        HealthDisplayUI.UpdateHealth(newHealth, maxHealth);
    }

    public void SetPlayer(PlayerCharacter playerCharacter)
    {
        _playerCharacter = playerCharacter;
        SubscribeToPlayerChanges();
    }
}