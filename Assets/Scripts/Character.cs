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
    public Weapon InitialWeapon;
    public Transform WeaponPosition;
    public Transform LookTarget;

    private Weapon _weapon;
    private Rigidbody _rigidbody;
    private Mover _mover;
    protected IInput _input;

    public Rigidbody Rigidbody => _rigidbody;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _mover = new Mover(this);

        if (InitialWeapon != null)
        {
            _weapon = Instantiate(InitialWeapon, WeaponPosition.position, WeaponPosition.rotation);
            _weapon.transform.parent = transform;
        }
    }

    protected virtual void Update()
    {
        _input.Read();
        if (_weapon == null) return;

        if (_input.UseWeaponInput)
        {
            _weapon.TryUse();
        }

        var fireArm = _weapon as FireArm;

        if (fireArm == null) return;

        if (_input.ReloadInput)
        {
            fireArm.Reload();
        }
    }

    protected virtual void FixedUpdate()
    {
        _mover.Move(_input.MovementInput);
        if (!LookTarget) return;
        _mover.RotateAtTransform(LookTarget);
    }
}