using Composition;
using Game.Weapons;
using UI;
using UnityEngine;

public class HUD : MonoBehaviour, IHUD
{
    private IHUDView _view;
    private PlayerCharacter _player;

    private void Awake()
    {
        var viewFactory = CompositionRoot.GetViewFactory();
        _view = viewFactory.CreateHUD();
    }

    public void Show()
    {
        _view.Show();
    }

    public void Hide()
    {
        _view.Hide();
    }

    public void SetPlayer(PlayerCharacter playerCharacter)
    {
        _player = playerCharacter;
        UnsubscribeFromPlayerChanges();
        SubscribeToPlayerChanges();
    }

    private void OnEnable()
    {
        if (_player != null)
        {
            SubscribeToPlayerChanges();
        }
    }

    private void OnDisable()
    {
        if (_player != null)
        {
            UnsubscribeFromPlayerChanges();
        }
    }


    private void SubscribeToPlayerChanges()
    {
        _player.WeaponManager.WeaponChanged += OnChangeWeapon;
        _player.WeaponManager.OnAmmoLeftChange += OnChangeAmmoLeft;
        _player.Health.OnHealthChange += OnPlayerHealthChange;
        // _player.ExperienceManager.LevelGained += OnPlayerLevelGained;
        // _player.Stats.SpeedUpdated += OnPlayerSpeedUpdated;
        // _player.Stats.PowerUpdated += OnPlayerPowerUpdated;
    }

    private void UnsubscribeFromPlayerChanges()
    {
        _player.WeaponManager.WeaponChanged -= OnChangeWeapon;
        _player.WeaponManager.OnAmmoLeftChange -= OnChangeAmmoLeft;
        _player.Health.OnHealthChange -= OnPlayerHealthChange;
        // _player.ExperienceManager.LevelGained -= OnPlayerLevelGained;
        // _player.Stats.SpeedUpdated -= OnPlayerSpeedUpdated;
        // _player.Stats.PowerUpdated -= OnPlayerPowerUpdated;
    }

    private void OnPlayerSpeedUpdated(int newAmount)
    {
        // _statDisplay.UpdateSpeed(newAmount);
    }

    private void OnPlayerPowerUpdated(int newAmount)
    {
        // _statDisplay.UpdatePower(newAmount);
    }

    private void OnPlayerLevelGained()
    {
        // _statDisplay.IncreaseLevel();
    }

    private void OnChangeWeapon(Weapon newWeapon)
    {
        _view.SetWeapon(newWeapon.Icon);

        if (newWeapon is Firearm firearm)
        {
            _view.SetAmmo(firearm.AmmoLeft, firearm.MagazineSize);
        }
        else
        {
            _view.SetAmmo(-1, -1);
        }
    }

    private void OnChangeAmmoLeft(int ammoLeft)
    {
        _view.SetAmmoLeft(ammoLeft);
    }

    private void OnPlayerHealthChange(float newHealth, float maxHealth)
    {
        _view.SetHealth(newHealth, maxHealth);
    }
}