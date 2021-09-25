using UnityEngine;

public class Mover
{
    private Character _character;

    public Mover(Character character)
    {
        _character = character;
    }

    public void Move(Vector2 moveInput)
    {
        _character.Rigidbody.velocity = new Vector3(moveInput.x, 0, moveInput.y) * Time.deltaTime * _character.MovementSettings.Speed;
    }

    public void RotateAt(Vector3 targetPosition)
    {
        var directionToLook = targetPosition - _character.Rigidbody.position;
        var targetRotation = Mathf.Atan2(directionToLook.z, directionToLook.x) * Mathf.Rad2Deg - 90f;
        // transform.rotation = Quaternion.Euler(new Vector3(0, -targetRotation, 0));
        _character.Rigidbody.rotation = Quaternion.Euler(new Vector3(0, -targetRotation, 0));
    }
}