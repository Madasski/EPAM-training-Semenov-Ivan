using System.Collections.Generic;
using Composition;
using UI;
using UnityEngine;

public class HealthBarDrawer : MonoBehaviour, IHealthBarDrawer
{
    private Dictionary<Health, IHealthBarView> _healthBarUIs = new Dictionary<Health, IHealthBarView>();

    private ILevelManager _levelManager;
    private IViewFactory _viewFactory;

    private void Awake()
    {
        _levelManager = CompositionRoot.GetLevelManager();
        _viewFactory = CompositionRoot.GetViewFactory();
    }

    private void OnEnable()
    {
        _levelManager.EnemySpawned += DrawHealthBarForEnemy;
        _levelManager.EnemyDied += RemoveHealthBarForEnemy;
    }

    private void OnDisable()
    {
        _levelManager.EnemySpawned -= DrawHealthBarForEnemy;
        _levelManager.EnemyDied -= RemoveHealthBarForEnemy;
    }

    private void DrawHealthBarForEnemy(EnemyCharacter enemy)
    {
        DrawHealthBar(enemy.Health);
    }

    public void DrawHealthBar(Health health)
    {
        var view = _viewFactory.CreateHealthBarView();
        view.SetTarget(health);

        _healthBarUIs.Add(health, view);
    }

    private void RemoveHealthBarForEnemy(EnemyCharacter enemy)
    {
        RemoveHealthBar(enemy.Health);
    }

    public void RemoveHealthBar(Health health)
    {
        var view = _healthBarUIs[health];
        _healthBarUIs.Remove(health);
        view.RemoveItself();
    }
}