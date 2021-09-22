using System;
using Game.Weapons;
using UnityEngine;

[Serializable]
public class MovementSettings
{
    public float Speed;
}

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviour
{
    public MovementSettings MovementSettings;
    public Weapon _weapon;
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
        if (_input.AttackInput)
        {
            _weapon.Shoot();
        }

        if (_input.ReloadInput)
        {
            _weapon.Reload();
        }
    }

    protected virtual void FixedUpdate()
    {
        _mover.Move(_input.MovementInput);
    }
}