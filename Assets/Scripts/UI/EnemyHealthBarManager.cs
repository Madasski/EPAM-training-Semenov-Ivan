using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarManager : MonoBehaviour
{
    public HealthBarUI HealthBarPrefab;

    private Dictionary<EnemyCharacter, HealthBarUI> _healthBarUis = new Dictionary<EnemyCharacter, HealthBarUI>();

    public void DrawHealthBarForEnemy(EnemyCharacter enemyCharacter)
    {
        var healthBar = Instantiate(HealthBarPrefab, transform);
        healthBar.SetTarget(enemyCharacter.Health);

        enemyCharacter.Died += RemoveHealthBar;
        _healthBarUis.Add(enemyCharacter, healthBar);
    }

    private void RemoveHealthBar(Character character)
    {
        if (character is EnemyCharacter enemyCharacter) RemoveHealthBar(enemyCharacter);
    }

    private void RemoveHealthBar(EnemyCharacter enemyCharacter)
    {
        enemyCharacter.Died -= RemoveHealthBar;
        if (_healthBarUis.TryGetValue(enemyCharacter, out var healthBar))
        {
            _healthBarUis.Remove(enemyCharacter);
            Destroy(healthBar.gameObject);
        }
    }
}