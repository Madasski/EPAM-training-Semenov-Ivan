using System;

public interface IHealth : IDamageable
{
    event Action OnHealthReachedZero;
    event Action<float, float> OnHealthChange;
    void SetMaxHealth(float maxHealth);
    void Restore();
    void RestoreGradually(float healthPerSecond);
}