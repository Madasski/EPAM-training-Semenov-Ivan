using System;
using UnityEngine;

public interface IInput
{
    event Action PausePressed;

    Vector2 MovementInput { get; }
    bool UseWeaponInput { get; }
    bool[] UseSkillInput { get; }
    bool ReloadInput { get; }
    int ChangeWeaponInput { get; }
    Vector2 HorizontalMouseWorldPosition { get; }
}