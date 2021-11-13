using UnityEngine;

public class Mover
{
    private Character _character;

    public Mover(Character character)
    {
        _character = character;
    }

    public Vector3 Velocity => _character.Rigidbody.velocity;

    public void Move(Vector2 moveInput)
    {
        _character.Rigidbody.velocity = new Vector3(moveInput.x, 0, moveInput.y) * Time.deltaTime * _character.Stats.Speed;
    }
    
    public void DashAtLookDirection(float distance)
    {
        _character.Rigidbody.MovePosition(_character.Rigidbody.position + _character.transform.forward * distance);
    }

    public void RotateAtTransform(Transform transform)
    {
        if (transform == null) return;

        Vector3 targetPosition = transform.position;
        if (transform is RectTransform)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hit))
            {
                return;
            }

            targetPosition = hit.point;
        }

        RotateAt(targetPosition);
    }

    public void RotateAt(Vector3 targetPosition)
    {
        var directionToLook = targetPosition - _character.Rigidbody.position;
        var targetRotation = Mathf.Atan2(directionToLook.z, directionToLook.x) * Mathf.Rad2Deg - 90f;
        _character.Rigidbody.rotation = Quaternion.Euler(new Vector3(0, -targetRotation, 0));
    }
}