using System.Collections.Generic;
using Composition;
using Core;
using UI;
using UnityEngine;

public class HealthBarDrawer : MonoBehaviour, IHealthBarDrawer
{
    private Dictionary<Health, IHealthBar> _healthBarUIs = new Dictionary<Health, IHealthBar>();

    private ILevelManager _levelManager;
    private IViewFactory _viewFactory;

    private IResourceManager _resourceManager;

    private void Awake()
    {
        _resourceManager = CompositionRoot.GetResourceManager();
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
        var go = new GameObject("HealthBar", typeof(HealthBar));
        var healthBar = go.GetComponent<IHealthBar>();
        healthBar.SetTarget(health);

        _healthBarUIs.Add(health, healthBar);
    }

    private void RemoveHealthBarForEnemy(EnemyCharacter enemy)
    {
        RemoveHealthBar(enemy.Health);
    }

    public void RemoveHealthBar(Health health)
    {
        var healthBar = _healthBarUIs[health];
        _healthBarUIs.Remove(health);
        healthBar.DestroyItself();
    }
}