using System;
using Madasski.Stats;

public interface ICharacter
{
    event Action<ICharacter> Died;
    IHealth Health { get; }
    IMover Mover { get; }
    ICharacterStatsController StatsController { get; }
}