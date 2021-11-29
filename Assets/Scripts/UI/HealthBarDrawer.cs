using System.Collections.Generic;
using Composition;
using UnityEngine;

public class HealthBarDrawer : MonoBehaviour, IHealthBarDrawer
{
    private Dictionary<Health, HealthBarUI> _healthBarUis = new Dictionary<Health, HealthBarUI>();

    private ILevelManager _levelManager;

    private void Awake()
    {
        _levelManager = CompositionRoot.GetLevelManager();
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
        // var healthBar = Instantiate(HealthBarPrefab, transform);
        // healthBar.SetTarget(health);
        //
        // health.OnHealthReachedZero += RemoveHealthBar;
        // _healthBarUis.Add(health, healthBar);
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