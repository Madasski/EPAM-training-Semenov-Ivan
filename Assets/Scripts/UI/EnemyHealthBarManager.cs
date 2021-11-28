using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarManager : MonoBehaviour
{
    public HealthBarUI HealthBarPrefab;

    private Dictionary<Health, HealthBarUI> _healthBarUis = new Dictionary<Health, HealthBarUI>();
    // private LevelManager _levelManager;

    // public void Init(LevelManager levelManager)
    // {
    //     _levelManager = levelManager;
    // _levelManager.EnemySpawned += DrawHealthBar;
    // }

    private void OnDisable()
    {
        // _levelManager.EnemySpawned -= DrawHealthBar;
    }

    public void DrawHealthBar(Health health)
    {
        var healthBar = Instantiate(HealthBarPrefab, transform);
        healthBar.SetTarget(health);

        // health.OnHealthReachedZero += RemoveHealthBar;
        _healthBarUis.Add(health, healthBar);
    }

    // private void RemoveHealthBar(Character character)
    // {
    //     if (character is EnemyCharacter enemyCharacter) RemoveHealthBar(enemyCharacter);
    // }

    private void RemoveHealthBar(Health health)
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