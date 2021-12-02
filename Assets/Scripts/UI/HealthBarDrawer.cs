using System.Collections.Generic;
using Composition;
using Core;
using UI;
using UnityEngine;

public class HealthBarDrawer : MonoBehaviour, IHealthBarDrawer
{
    private Dictionary<IHealth, IHealthBar> _healthBarUIs = new Dictionary<IHealth, IHealthBar>();

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

    private void DrawHealthBarForEnemy(IEnemyCharacter enemy)
    {
        DrawHealthBar(enemy.Health, enemy.Mover);
    }

    public void DrawHealthBar(IHealth health, IMover mover)
    {
        var go = new GameObject("HealthBar", typeof(HealthBar));
        var healthBar = go.GetComponent<IHealthBar>();
        healthBar.SetTarget(health, mover);

        _healthBarUIs.Add(health, healthBar);
    }

    private void RemoveHealthBarForEnemy(IEnemyCharacter enemy)
    {
        RemoveHealthBar(enemy.Health);
    }

    public void RemoveHealthBar(IHealth health)
    {
        var healthBar = _healthBarUIs[health];
        _healthBarUIs.Remove(health);
        healthBar.DestroyItself();
    }
}