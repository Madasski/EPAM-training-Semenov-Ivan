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
    }

    private void OnDisable()
    {
        _levelManager.EnemySpawned -= DrawHealthBarForEnemy;
    }

    private void DrawHealthBarForEnemy(EnemyCharacter enemy)
    {
        DrawHealthBar(enemy.Health);
    }

    public void DrawHealthBar(Health health)
    {
        var view = _viewFactory.CreateHealthBarView();
        // var healthBar = Instantiate(HealthBarPrefab, transform);
        view.SetTarget(health);

        // health.OnHealthReachedZero += RemoveHealthBar;
        _healthBarUIs.Add(health, view);
    }

    private void RemoveHealthBarForEnemy(EnemyCharacter enemy)
    {
        RemoveHealthBar(enemy.Health);
    }

    public void RemoveHealthBar(Health health)
    {
        // health.OnHealthReachedZero -= RemoveHealthBar;
        // _healthBarUis.Add(health, healthBar);
        // if (_healthBarUis.TryGetValue(enemyCharacter, out var healthBar))
        // {
        //     _healthBarUis.Remove(enemyCharacter);
        //     Destroy(healthBar.gameObject);
        // }
    }
}