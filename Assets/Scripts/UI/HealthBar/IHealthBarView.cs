using UnityEngine;

public interface IHealthBarView : IView
{
    void UpdatePosition(Vector2 position);
    void SetHealth(float newHealth, float maxHealth);
    void DestroyItself();
}