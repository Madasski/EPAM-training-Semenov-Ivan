using System;
using Madasski.Skills;
using Madasski.Stats;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviour
{
    public event Action<Character> Died;

    // public CharacterStats InitialStats;
    public Transform LookTarget;

    protected IInput _input;
    private Rigidbody _rigidbody;
    private Mover _mover;
    private WeaponManager _weaponManager;
    private Health _health;

    public Rigidbody Rigidbody => _rigidbody;
    public WeaponManager WeaponManager => _weaponManager;
    public Health Health => _health;
    public Mover Mover => _mover;

    public CharacterStatsController Stats;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _weaponManager = GetComponent<WeaponManager>();
        _health = GetComponent<Health>();
        _mover = new Mover(this);
        Stats = new CharacterStatsController();
    }

    protected virtual void OnEnable()
    {
        _health.SetMaxHealth(Stats.Health);
        Stats.HealthUpdated += _health.SetMaxHealth;
        _health.OnHealthReachedZero += Die;
        Died = delegate(Character character) { };
    }

    protected virtual void OnDisable()
    {
        Stats.HealthUpdated -= _health.SetMaxHealth;
        _health.OnHealthReachedZero -= Die;
        Died = delegate(Character character) { };
    }

    protected virtual void Update()
    {
        _input.Read();

        if (_input.UseWeaponInput)
        {
            _weaponManager.UseCurrentWeapon(Stats.Power);
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