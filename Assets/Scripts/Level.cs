using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> _enemySpawners;

    public List<EnemySpawner> EnemySpawners => _enemySpawners;
}