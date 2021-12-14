using System;
using Composition;
using UnityEngine;

[Serializable]
public class KillObjective : IObjective
{
    public event Action<IObjective> Completed;

    [SerializeField] private bool _isMain;
    [SerializeField] private EEnemies _enemyType;
    [SerializeField, Range(0, 50)] private int _numberToKill;

    private ILevelManager _levelManager;

    public bool IsMain => _isMain;

    public string Description => $"Kill {_numberToKill} of type {_enemyType.ToString()}";

    public void Init()
    {
        _levelManager = CompositionRoot.GetLevelManager();
        _levelManager.EnemyDied += OnEnemyDied;
    }

    private void OnEnemyDied(IEnemyCharacter enemy)
    {
        if (enemy.Type != _enemyType) return;

        _numberToKill--;
        if (_numberToKill < 1)
        {
            Completed?.Invoke(this);
        }
    }
}