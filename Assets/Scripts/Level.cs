using System.Collections.Generic;
using Composition;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> _enemySpawners;
    [SerializeField] private List<KillObjective> _killObjectives;
    [SerializeField] private AudioClip _levelMusic;

    public List<EnemySpawner> EnemySpawners => _enemySpawners;
    public List<IObjective> Objectives => new List<IObjective>(_killObjectives);

    private void Awake()
    {
        CompositionRoot.GetAudioManager().PlayMusic(_levelMusic);
    }
}