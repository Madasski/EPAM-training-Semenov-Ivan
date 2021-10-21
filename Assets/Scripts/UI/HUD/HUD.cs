using Game.Weapons;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public AmmoDisplayUI AmmoDisplayUI;
    public HealthDisplayUI HealthDisplayUI;
    public StatDisplay StatDisplay;

    private PlayerCharacter _playerCharacter;

    private void OnEnable()
    {
        if (_playerCharacter)
        {
            _playerCharacter.WeaponManager.WeaponChanged += ChangedWeapon;
            _playerCharacter.WeaponManager.OnAmmoLeftChange += OnChangeAmmoLeft;
            _playerCharacter.Health.OnHealthChange += OnPlayerHealthChange;
            _playerCharacter.ExperienceManager.LevelGained += OnPlayerLevelGained;
            _playerCharacter.Stats.SpeedUpgraded += OnPlayerSpeedUpgraded;
            _playerCharacter.Stats.PowerUpgraded += OnPlayerPowerUpgraded;
        }
    }

    private void OnDisable()
    {
        if (_playerCharacter)
        {
            _playerCharacter.WeaponManager.WeaponChanged -= ChangedWeapon;
            _playerCharacter.WeaponManager.OnAmmoLeftChange -= OnChangeAmmoLeft;
            _playerCharacter.Health.OnHealthChange -= OnPlayerHealthChange;
            _playerCharacter.ExperienceManager.LevelGained -= OnPlayerLevelGained;
            _playerCharacter.Stats.SpeedUpgraded -= OnPlayerSpeedUpgraded;
            _playerCharacter.Stats.PowerUpgraded -= OnPlayerPowerUpgraded;
        }
    }

    private void OnPlayerSpeedUpgraded(int newAmount)
    {
        StatDisplay.UpdateSpeed(newAmount);
    }

    private void OnPlayerPowerUpgraded(int newAmount)
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
        _playerCharacter.WeaponManager.WeaponChanged += ChangedWeapon;
        _playerCharacter.WeaponManager.OnAmmoLeftChange += OnChangeAmmoLeft;
        _playerCharacter.Health.OnHealthChange += OnPlayerHealthChange;
        _playerCharacter.ExperienceManager.LevelGained += OnPlayerLevelGained;
        _playerCharacter.Stats.SpeedUpgraded += OnPlayerSpeedUpgraded;
        _playerCharacter.Stats.PowerUpgraded += OnPlayerPowerUpgraded;
    }
}