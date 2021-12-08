using Composition;
using Game.Weapons;
using UI;
using UnityEngine;

public class HUD : MonoBehaviour, IHUD
{
    private IHUDView _view;
    private IPlayerCharacter _player;

    private void Awake()
    {
        var viewFactory = CompositionRoot.GetViewFactory();
        _view = viewFactory.CreateHUD();
    }

    private void Start()
    {
        SetPlayerSpeed(_player.StatsController.Speed);
        SetPlayerPower(_player.StatsController.Power);
        SetPlayerLevel(_player.ExperienceManager.CurrentLevel);
    }

    public void Show()
    {
        _view.Show();
    }

    public void Hide()
    {
        _view.Hide();
    }

    public void SetPlayer(IPlayerCharacter playerCharacter)
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
        _player.ExperienceManager.LevelGained += SetPlayerLevel;
        _player.StatsController.SpeedUpdated += SetPlayerSpeed;
        _player.StatsController.PowerUpdated += SetPlayerPower;
    }

    private void UnsubscribeFromPlayerChanges()
    {
        _player.WeaponManager.WeaponChanged -= OnChangeWeapon;
        _player.WeaponManager.OnAmmoLeftChange -= OnChangeAmmoLeft;
        _player.Health.OnHealthChange -= OnPlayerHealthChange;
        _player.ExperienceManager.LevelGained -= SetPlayerLevel;
        _player.StatsController.SpeedUpdated -= SetPlayerSpeed;
        _player.StatsController.PowerUpdated -= SetPlayerPower;
    }

    private void SetPlayerSpeed(int newAmount)
    {
        _view.SetSpeed(newAmount);
    }

    private void SetPlayerPower(int newAmount)
    {
        _view.SetPower(newAmount);
    }

    private void SetPlayerLevel(int level)
    {
        _view.SetLevel(level);
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