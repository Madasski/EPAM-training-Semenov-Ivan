using UnityEngine;

public interface IInput
{
    public Vector2 MovementInput { get; }
    void Read();
}