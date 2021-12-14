using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> _enemySpawners;
    [SerializeField] private List<KillObjective> _killObjectives;
    // [SerializeField] private TimeObjective _timeObjective;

    public List<EnemySpawner> EnemySpawners => _enemySpawners;
    public List<IObjective> Objectives => new List<IObjective>(_killObjectives);
}