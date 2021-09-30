using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarManager : MonoBehaviour
{
    public HealthBarUI HealthBarPrefab;

    private Dictionary<EnemyCharacter, HealthBarUI> _healthBarUis = new Dictionary<EnemyCharacter, HealthBarUI>();

    public void DrawHealthBarForEnemy(EnemyCharacter enemyCharacter)
    {
        var healthBar = Instantiate(HealthBarPrefab,transform);
        healthBar.SetTarget(enemyCharacter.Health);

        enemyCharacter.OnDie += RemoveHealthBar;
        _healthBarUis.Add(enemyCharacter, healthBar);
    }

    private void RemoveHealthBar(EnemyCharacter enemyCharacter)
    {
        enemyCharacter.OnDie -= RemoveHealthBar;
        if (_healthBarUis.TryGetValue(enemyCharacter, out var healthBar))
        {
            _healthBarUis.Remove(enemyCharacter);
            Destroy(healthBar.gameObject);
        }
    }
}