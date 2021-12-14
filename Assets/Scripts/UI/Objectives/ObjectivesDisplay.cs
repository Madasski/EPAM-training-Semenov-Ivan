using System.Collections.Generic;
using Composition;
using UI;
using UnityEngine;

public class ObjectivesDisplay : MonoBehaviour
{
    private Dictionary<IObjective, ObjectiveView> _objectives;
    private IViewFactory _viewFactory;

    private void Awake()
    {
        _viewFactory = CompositionRoot.GetViewFactory();
        _objectives = new Dictionary<IObjective, ObjectiveView>();
    }

    public void AddObjective(IObjective objective)
    {
        var objectiveView = _viewFactory.CreateObjective();
        objectiveView.SetParent(transform);
        objectiveView.SetDescription(objective.Description);

        _objectives.Add(objective, objectiveView);

        objective.Completed += OnObjectiveCompleted;
    }

    private void OnObjectiveCompleted(IObjective objective)
    {
        _objectives[objective].SetCompleted();
    }
}