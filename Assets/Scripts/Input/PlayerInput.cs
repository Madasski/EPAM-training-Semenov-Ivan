using UnityEngine;

public class PlayerInput : IInput
{
    private Vector2 _movementInput;
    private bool _attackInput;
    private bool _reloadInput;
    private int _changeWeaponInput;

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

    public bool UseWeaponInput => _attackInput;
    public bool ReloadInput => _reloadInput;
    public int ChangeWeaponInput => _changeWeaponInput;

    public void Read()
    {
        _movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _attackInput = Input.GetButtonDown("Fire1") || Input.GetButton("Fire1");
        _reloadInput = Input.GetKeyDown(KeyCode.R);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _changeWeaponInput = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _changeWeaponInput = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _changeWeaponInput = 3;
        }
        else
        {
            _changeWeaponInput = 0;
        }
    }
}