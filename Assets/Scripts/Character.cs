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
    public Transform LookTarget;

    private Rigidbody _rigidbody;
    private Mover _mover;
    private WeaponManager _weaponManager;
    protected IInput _input;

    public Rigidbody Rigidbody => _rigidbody;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _mover = new Mover(this);
        _weaponManager = GetComponent<WeaponManager>();
    }

    protected virtual void Update()
    {
        _input.Read();

        if (_input.UseWeaponInput)
        {
            _weaponManager.UseCurrentWeapon();
        }

        if (_input.ReloadInput)
        {
            _weaponManager.ReloadCurrentWeapon();
        }
    }

    protected virtual void FixedUpdate()
    {
        _mover.Move(_input.MovementInput);
        if (!LookTarget) return;
        _mover.RotateAtTransform(LookTarget);
    }
}