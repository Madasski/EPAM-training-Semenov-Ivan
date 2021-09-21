using UnityEngine;

public interface IInput
{
    public Vector2 MovementInput { get; }
    public bool AttackInput { get; }
    bool ReloadInput { get; }
    void Read();
}