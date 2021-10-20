using System;
using Game.Weapons;
using Madasski;
using UnityEngine;

// [Serializable]
// public class MovementSettings
// {
//     public float Speed;
// }

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviour
{
    public event Action<Character> Died;

    // public MovementSettings MovementSettings;
    public CharacterStats InitialStats;
    public Transform LookTarget;

    protected IInput _input;
    private Rigidbody _rigidbody;
    private Mover _mover;
    private WeaponManager _weaponManager;
    private Health _health;
    private CharacterStats _stats;

    public Rigidbody Rigidbody => _rigidbody;
    public WeaponManager WeaponManager => _weaponManager;
    public Health Health => _health;
    public CharacterStats Stats => _stats;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _weaponManager = GetComponent<WeaponManager>();
        _health = GetComponent<Health>();
        _mover = new Mover(this);
        _stats = InitialStats;

        _health.SetMaxHealth(_stats.Health);
    }

    protected virtual void OnEnable()
    {
        _health.OnHealthReachedZero += Die;
        Died = delegate(Character character) { };
    }

    protected virtual void OnDisable()
    {
        _health.OnHealthReachedZero -= Die;
        Died = delegate(Character character) { };
    }

    protected virtual void Update()
    {
        _input.Read();

        if (_input.UseWeaponInput)
        {
            _weaponManager.UseCurrentWeapon(_stats.Power);
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
        Died?.Invoke(this);
    }
}