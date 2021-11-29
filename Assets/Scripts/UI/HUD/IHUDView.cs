﻿using UnityEngine;

namespace UI
{
    public interface IHUDView : IView
    {
        void SetAmmo(int ammoLeft, int magazineSize);
        void SetHealth(float newHealth, float maxHealth);
        void SetWeapon(Sprite newWeaponIcon);
        void SetAmmoLeft(int ammoLeft);
    }
}