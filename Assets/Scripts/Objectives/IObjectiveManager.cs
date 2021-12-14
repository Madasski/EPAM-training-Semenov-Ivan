using System;
using System.Collections.Generic;

public interface IObjectiveManager
{
    event Action AllObjectivesCompleted;
    event Action<List<IObjective>> ObjectivesUpdated;
    void Init(List<IObjective> currentLevelObjectives);
}