using System;
using System.Collections.Generic;
using Game.Weapons;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public event Action<Weapon> WeaponChanged;
    public event Action<int> OnAmmoLeftChange;

    public Transform WeaponPosition;
    public List<Weapon> Weapons = new List<Weapon>(3);

    private Weapon _currentWeapon;

    private void Start()
    {
        ChangeWeapon(1);
    }

    public void UseCurrentWeapon(float power)
    {
        _currentWeapon.TryUse(power);
        if (_currentWeapon is Firearm firearm)
        {
            OnAmmoLeftChange?.Invoke(firearm.AmmoLeft);
        }
    }

    public void ReloadCurrentWeapon()
    {
        if (_currentWeapon is Firearm firearm)
        {
            firearm.Reload();
            OnAmmoLeftChange?.Invoke(firearm.AmmoLeft);
        }
    }

    public void ChangeWeapon(int weaponSlot)
    {
        if (weaponSlot > Weapons.Count) return;

        if (_currentWeapon != null) Destroy(_currentWeapon.gameObject);

        var newWeaponPrefab = Weapons[weaponSlot - 1];
        _currentWeapon = Instantiate(newWeaponPrefab, WeaponPosition.position, WeaponPosition.rotation);
        _currentWeapon.transform.parent = transform;

        WeaponChanged?.Invoke(_currentWeapon);
    }
}