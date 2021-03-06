using System;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    public event Action OnHealthReachedZero;
    public event Action<float, float> OnHealthChange;

    private float _currentHealth;
    private float _maxHealth = 100f;

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    public void SetMaxHealth(float maxHealth)
    {
        _maxHealth = maxHealth;
        Restore();
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth < 0) _currentHealth = 0;

        OnHealthChange?.Invoke(_currentHealth, _maxHealth);
        if (_currentHealth <= 0)
            OnHealthReachedZero?.Invoke();
    }

    public void Restore()
    {
        _currentHealth = _maxHealth;
        OnHealthChange?.Invoke(_currentHealth, _maxHealth);
    }

    public void RestoreGradually(float healthPerSecond)
    {
        if (_currentHealth >= _maxHealth) return;
        _currentHealth += healthPerSecond * Time.deltaTime;
        OnHealthChange?.Invoke(_currentHealth, _maxHealth);
    }
}