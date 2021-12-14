using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : IObjectiveManager
{
    public event Action AllObjectivesCompleted;
    public event Action<List<IObjective>> ObjectivesUpdated;

    public List<IObjective> ObjectivesToComplete { get; private set; }

    public void Init(List<IObjective> currentLevelObjectives)
    {
        ObjectivesToComplete = new List<IObjective>();

        foreach (var objective in currentLevelObjectives)
        {
            objective.Init();
            ObjectivesToComplete.Add(objective);
            objective.Completed += OnObjectiveCompleted;
        }

        ObjectivesUpdated.Invoke(ObjectivesToComplete);
    }

    private void OnObjectiveCompleted(IObjective completedObjective)
    {
        completedObjective.Completed -= OnObjectiveCompleted;
        ObjectivesToComplete.Remove(completedObjective);

        if (ObjectivesToComplete.Count <= 0)
        {
            AllObjectivesCompleted.Invoke();
        }
    }
}