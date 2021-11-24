using Composition;
using Game.Weapons;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private AmmoDisplayUI _ammoDisplayUI;
    [SerializeField] private HealthDisplayUI _healthDisplayUI;
    [SerializeField] private StatDisplay _statDisplay;
    private PlayerCharacter _playerCharacter;

    // public AmmoDisplayUI AmmoDisplayUI => _ammoDisplayUI;
    // public HealthDisplayUI HealthDisplayUI => _healthDisplayUI;
    // public StatDisplay StatDisplay => _statDisplay;

    private void Awake()
    {
        _playerCharacter = CompositionRoot.GetPlayerCharacter();
    }

    private void OnEnable()
    {
        SubscribeToPlayerChanges();
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
        _statDisplay.UpdateSpeed(newAmount);
    }

    private void OnPlayerPowerUpdated(int newAmount)
    {
        _statDisplay.UpdatePower(newAmount);
    }

    private void OnPlayerLevelGained()
    {
        _statDisplay.IncreaseLevel();
    }

    private void ChangedWeapon(Weapon newWeapon)
    {
        _ammoDisplayUI.WeaponIcon.sprite = newWeapon.Icon;

        if (newWeapon is Firearm firearm)
        {
            _ammoDisplayUI.UpdateAmmoCounter(firearm.AmmoLeft, firearm.MagazineSize);
        }
        else
        {
            _ammoDisplayUI.UpdateAmmoCounter(-1, -1);
        }
    }

    private void OnChangeAmmoLeft(int ammoLeft)
    {
        _ammoDisplayUI.UpdateAmmoCounter(ammoLeft);
    }

    private void OnPlayerHealthChange(float newHealth, float maxHealth)
    {
        _healthDisplayUI.UpdateHealth(newHealth, maxHealth);
    }
}