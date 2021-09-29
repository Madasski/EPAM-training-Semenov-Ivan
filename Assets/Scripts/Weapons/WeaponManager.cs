using Game.Weapons;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Transform WeaponPosition;
    public Weapon InitialWeapon;

    private Weapon _currentWeapon;

    private void Awake()
    {
        if (InitialWeapon != null)
        {
            _currentWeapon = Instantiate(InitialWeapon, WeaponPosition.position, WeaponPosition.rotation);
            _currentWeapon.transform.parent = transform;
        }
    }

    public void UseCurrentWeapon()
    {
        _currentWeapon.TryUse();
    }

    public void ReloadCurrentWeapon()
    {
        (_currentWeapon as Firearm)?.Reload();
    }
}