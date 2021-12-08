using System;

namespace Madasski.Stats
{
    public interface ICharacterStatsController
    {
        event Action<float> HealthUpdated;
        event Action<int> PowerUpdated;
        event Action<int> SpeedUpdated;

        CharacterStats Stats { get; }
        int Speed { get; set; }
        int Power { get; set; }
        float Health { get; set; }
    }
}