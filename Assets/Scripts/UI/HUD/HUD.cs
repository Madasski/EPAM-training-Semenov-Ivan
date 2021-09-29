using Game.Weapons;
using UnityEngine;

public class HUD : MonoBehaviour
{
    private PlayerCharacter _playerCharacter;
    public AmmoDisplayUI AmmoDisplayUI;

    private void OnEnable()
    {
        if (_playerCharacter)
        {
            _playerCharacter.WeaponManager.OnWeaponChange += OnChangeWeapon;
            _playerCharacter.WeaponManager.OnAmmoLeftChange += OnChangeAmmoLeft;
        }
    }

    private void OnDisable()
    {
        if (_playerCharacter)
        {
            _playerCharacter.WeaponManager.OnWeaponChange -= OnChangeWeapon;
            _playerCharacter.WeaponManager.OnAmmoLeftChange -= OnChangeAmmoLeft;
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

    public void SetPlayer(PlayerCharacter playerCharacter)
    {
        _playerCharacter = playerCharacter;
        _playerCharacter.WeaponManager.OnWeaponChange += OnChangeWeapon;
        _playerCharacter.WeaponManager.OnAmmoLeftChange += OnChangeAmmoLeft;
    }
}