using UnityEngine;

public class PlayerInput : IInput
{
    private Vector2 _movementInput;
    private bool _attackInput;
    private bool _reloadInput;

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

    public bool AttackInput => _attackInput;
    public bool ReloadInput => _reloadInput;

    public void Read()
    {
        _movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _attackInput = Input.GetButtonDown("Fire1");
        _reloadInput = Input.GetKeyDown(KeyCode.R);
    }
}