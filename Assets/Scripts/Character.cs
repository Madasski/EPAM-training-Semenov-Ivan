using UnityEngine;

[System.Serializable]
public class MovementSettings
{
    public float Speed;
}

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviour
{
    public MovementSettings MovementSettings;
    private Rigidbody _rigidbody;
    private Mover _mover;
    protected IInput _input;

    public Rigidbody Rigidbody => _rigidbody;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _mover = new Mover(this);
    }

    protected virtual void Update()
    {
        _input.Read();
    }

    protected virtual void FixedUpdate()
    {
        _mover.Move(_input.MovementInput);
    }

    private void Shoot()
    {
        
    }
}