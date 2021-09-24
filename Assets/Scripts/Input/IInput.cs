using UnityEngine;

public interface IInput
{
    public Vector2 MovementInput { get; }
    public bool UseInput { get; }
    bool ReloadInput { get; }
    void Read();
}