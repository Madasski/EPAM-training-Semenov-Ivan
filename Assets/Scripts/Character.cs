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
    public event Action<Character> OnDie;

    public MovementSettings MovementSettings;
    public Transform LookTarget;

    private Rigidbody _rigidbody;
    private Mover _mover;
    private WeaponManager _weaponManager;
    private Health _health;
    protected IInput _input;

    public Rigidbody Rigidbody => _rigidbody;
    public WeaponManager WeaponManager => _weaponManager;
    public Health Health => _health;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _mover = new Mover(this);
        _weaponManager = GetComponent<WeaponManager>();

        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.OnHealthReachedZero += Die;
        OnDie = delegate(Character character) { };
    }

    protected virtual void OnDisable()
    {
        _health.OnHealthReachedZero -= Die;
        OnDie = delegate(Character character) { };
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

        if (_input.ChangeWeaponInput != 0)
        {
            _weaponManager.ChangeWeapon(_input.ChangeWeaponInput);
        }
    }

    protected virtual void FixedUpdate()
    {
        _mover.Move(_input.MovementInput);
        if (!LookTarget) return;
        _mover.RotateAtTransform(LookTarget);
    }

    protected virtual void Die()
    {
        OnDie?.Invoke(this);
    }
}