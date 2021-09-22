using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public int MaxHealth;

    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
            Destroy(gameObject);
    }
}