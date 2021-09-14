using UnityEngine;

public class PlayerInput
{
    private Vector2 _movementInput;

    public Vector2 MovementInput
    {
        get
        {
            if (_movementInput.magnitude > 1)
            {
                _movementInput.Normalize();
            }

            return _movementInput;
        }
    }

    public void Read()
    {
        _movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}