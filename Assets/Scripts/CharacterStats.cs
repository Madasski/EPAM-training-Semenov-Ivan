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
        public event Action<int> PowerUpgraded;
        public event Action<int> SpeedUpgraded;
        
        public int Speed;
        public float Health;
        public int Power;

        public void UpgradeSpeed(int amount)
        {
            Speed += amount;
            SpeedUpgraded?.Invoke(Speed);
        }

        public void UpgradeHealth(float amount)
        {
            Health += amount;
            HealthUpgraded?.Invoke(Health);
        }

        public void UpgradePower(int amount)
        {
            Power += amount;
            PowerUpgraded?.Invoke(Power);
        }
    }
}