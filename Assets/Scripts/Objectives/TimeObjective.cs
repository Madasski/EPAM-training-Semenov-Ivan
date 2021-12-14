using System;
using UnityEngine;

[Serializable]
public class TimeObjective : IObjective
{
    public event Action<IObjective> Completed;

    [SerializeField, Range(0, 180)] private int _secondsToCompleteLevel;

    public bool IsMain { get; }
    public string Description { get; }

    public void Init()
    {
    }
}