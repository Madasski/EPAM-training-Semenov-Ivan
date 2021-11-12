using System;
using Madasski.Stats;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviour
{
    public event Action<Character> Died;

    public Transform LookTarget;

    private Rigidbody _rigidbody;
    protected Mover _mover;
    private Health _health;

    public Rigidbody Rigidbody => _rigidbody;
    public Health Health => _health;
    public Mover Mover => _mover;

    public CharacterStatsController Stats;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
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
        // _input.Read();
    }

    protected virtual void FixedUpdate()
    {
        // _mover.Move();
        // if (!LookTarget) return;
        // _mover.RotateAtTransform(LookTarget);
    }

    protected virtual void Die()
    {
        Died?.Invoke(this);
    }
}