using UnityEngine;

public class PlayerInput : IInput
{
    private Vector2 _movementInput;
    private bool _attackInput;
    private bool _reloadInput;
    private int _changeWeaponInput;
    private Vector2 _horizontalMouseWorldWorldPosition;

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
    public bool[] UseSkillInput { get; } = new bool[3];
    public bool ReloadInput => _reloadInput;
    public int ChangeWeaponInput => _changeWeaponInput;
    public Vector2 HorizontalMouseWorldPosition => _horizontalMouseWorldWorldPosition;

    public void Read()
    {
        _movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _attackInput = Input.GetButtonDown("Fire1") || Input.GetButton("Fire1");
        _reloadInput = Input.GetKeyDown(KeyCode.R);


        _horizontalMouseWorldWorldPosition = GetMouseWorldPosition();


        UseSkillInput[0] = Input.GetKeyDown(KeyCode.Q);
        UseSkillInput[1] = Input.GetKeyDown(KeyCode.E) || Input.GetKey(KeyCode.E);
        UseSkillInput[2] = Input.GetKeyDown(KeyCode.F);


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

    private Vector2 GetMouseWorldPosition()
    {
        Plane plane = new Plane(Vector3.up, 0);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector2 mousePosition = Vector2.zero;
        if (plane.Raycast(ray, out float distance))
        {
            mousePosition = new Vector2(ray.GetPoint(distance).x, ray.GetPoint(distance).z);
        }

        return mousePosition;
    }
}