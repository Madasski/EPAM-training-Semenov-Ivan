using UnityEngine;

namespace UI
{
    public class HUDView : SimpleView, IHUDView
    {
        [SerializeField] private AmmoDisplayUI _ammoDisplayUI;
        [SerializeField] private HealthDisplayUI _healthDisplayUI;
        [SerializeField] private StatDisplay _statDisplay;

        public void SetAmmoLeft(int ammoLeft)
        {
            _ammoDisplayUI.UpdateAmmoCounter(ammoLeft);
        }

        public void SetAmmo(int ammoLeft, int magazineSize)
        {
            _ammoDisplayUI.UpdateAmmoCounter(ammoLeft, magazineSize);
        }

        public void SetHealth(float newHealth, float maxHealth)
        {
            _healthDisplayUI.UpdateHealth(newHealth, maxHealth);
        }

        public void SetWeapon(Sprite newWeaponIcon)
        {
            _ammoDisplayUI.WeaponIcon.sprite = newWeaponIcon;
        }

        public void SetLevel(int level)
        {
            _statDisplay.SetLevel(level);
        }

        public void SetSpeed(int newSpeed)
        {
            _statDisplay.SetSpeed(newSpeed);
        }

        public void SetPower(int newAmount)
        {
            _statDisplay.SetPower(newAmount);
        }
    }
}