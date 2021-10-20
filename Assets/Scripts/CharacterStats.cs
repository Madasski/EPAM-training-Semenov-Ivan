using System;

namespace Madasski
{
    [Serializable]
    public class CharacterStats
    {
        // private float _speed;
        // private float _health;
        // private float _power;

        public event Action<float> HealthUpgraded;
        
        public float Speed;
        public float Health;
        public float Power;

        public void UpgradeSpeed(float amount)
        {
            Speed += amount;
        }

        public void UpgradeHealth(float amount)
        {
            Health += amount;
            HealthUpgraded?.Invoke(Health);
        }

        public void UpgradePower(float amount)
        {
            Power += amount;
        }
    }
}