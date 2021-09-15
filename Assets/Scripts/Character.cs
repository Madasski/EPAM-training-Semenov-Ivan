using UnityEngine;

[System.Serializable]
public class MovementSettings
{
    public float Speed;
}

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    public MovementSettings MovementSettings;
    private Rigidbody _rigidbody;
    private Mover _mover;
    private PlayerInput _input;

    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _mover = new Mover(this);
        _input = new PlayerInput();
    }

    private void FixedUpdate()
    {
        _input.Read();
        _mover.Move(_input.MovementInput);
    }
}