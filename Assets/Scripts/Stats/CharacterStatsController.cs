using System;
using Core.Saving;

namespace Madasski.Stats
{
    public class CharacterStatsController : ISaveLoad
    {
        public event Action<float> HealthUpdated;
        public event Action<int> PowerUpdated;
        public event Action<int> SpeedUpdated;

        private CharacterStats _characterStats;

        public int Speed
        {
            get => _characterStats.Speed;
            set
            {
                _characterStats.Speed = value;
                SpeedUpdated?.Invoke(_characterStats.Speed);
            }
        }

        public int Power
        {
            get => _characterStats.Power;
            set
            {
                _characterStats.Power = value;
                PowerUpdated?.Invoke(_characterStats.Power);
            }
        }

        public float Health
        {
            get => _characterStats.Health;
            set
            {
                _characterStats.Health = value;
                HealthUpdated?.Invoke(_characterStats.Health);
            }
        }

        public void Init(CharacterStats characterStats)
        {
            _characterStats = characterStats;
        }

        public void Save(GameData gameData)
        {
            gameData.CharacterStats = _characterStats;
        }

        public void Load(GameData gameData)
        {
            Health = gameData.CharacterStats.Health;
            Power = gameData.CharacterStats.Power;
            Speed = gameData.CharacterStats.Speed;
        }
    }
}