using UnityEngine;

public interface IMover
{
    Transform Transform { get; }
    Vector3 Velocity { get; }

    void Move(Vector2 moveInput);
    void DashAtLookDirection(float distance);
    void RotateAtTransform(Transform transform);
    void RotateAt(Vector2 inputHorizontalMouseWorldPosition);
}