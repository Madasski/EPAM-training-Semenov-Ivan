using Game.Weapons;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public AmmoDisplayUI AmmoDisplayUI;
    public HealthDisplayUI HealthDisplayUI;

    private PlayerCharacter _playerCharacter;

    private void OnEnable()
    {
        if (_playerCharacter)
        {
            _playerCharacter.WeaponManager.OnWeaponChange += OnChangeWeapon;
            _playerCharacter.WeaponManager.OnAmmoLeftChange += OnChangeAmmoLeft;
            _playerCharacter.Health.OnHealthChange += OnPlayerHealthChange;
        }
    }

    private void OnDisable()
    {
        if (_playerCharacter)
        {
            _playerCharacter.WeaponManager.OnWeaponChange -= OnChangeWeapon;
            _playerCharacter.WeaponManager.OnAmmoLeftChange -= OnChangeAmmoLeft;
            _playerCharacter.Health.OnHealthChange -= OnPlayerHealthChange;
        }
    }

    private void OnChangeWeapon(Weapon newWeapon)
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

    private void OnPlayerHealthChange(int newHealth, int maxHealth)
    {
        HealthDisplayUI.UpdateHealth(newHealth, maxHealth);
    }

    public void SetPlayer(PlayerCharacter playerCharacter)
    {
        _playerCharacter = playerCharacter;
        _playerCharacter.WeaponManager.OnWeaponChange += OnChangeWeapon;
        _playerCharacter.WeaponManager.OnAmmoLeftChange += OnChangeAmmoLeft;
        _playerCharacter.Health.OnHealthChange += OnPlayerHealthChange;
    }
}