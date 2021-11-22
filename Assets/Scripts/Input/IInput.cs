using UnityEngine;

public interface IInput
{
    public Vector2 MovementInput { get; }
    public bool UseWeaponInput { get; }
    public bool[] UseSkillInput { get; }
    public bool ReloadInput { get; }
    public int ChangeWeaponInput { get; }
    public Vector2 HorizontalMouseWorldPosition { get; }

    public void Read();
}