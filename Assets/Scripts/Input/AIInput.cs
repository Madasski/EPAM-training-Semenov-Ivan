using UnityEngine;

public class AIInput : IInput
{
    public Vector2 MovementInput { get; }
    public bool AttackInput { get; }
    public bool ReloadInput { get; }

    public void Read()
    {
    }
}