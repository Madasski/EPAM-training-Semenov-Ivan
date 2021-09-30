using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public event Action OnHealthReachedZero;
    public event Action<int,int> OnHealthChange;

    public int MaxHealth;

    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth < 0) _currentHealth = 0;
        
        OnHealthChange?.Invoke(_currentHealth,MaxHealth);
        if (_currentHealth <= 0)
            OnHealthReachedZero?.Invoke();
    }
}