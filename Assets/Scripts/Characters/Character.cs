using System;
using Madasski.Stats;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Character : MonoBehaviour, ICharacter
{
    public event Action<Character> Died;

    public Transform LookTarget;

    private Rigidbody _rigidbody;
    protected IMover _mover;
    private IHealth _health;

    public Rigidbody Rigidbody => _rigidbody;
    public IHealth Health => _health;
    public IMover Mover => _mover;

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
    }

    protected virtual void FixedUpdate()
    {
    }

    protected virtual void Die()
    {
        Died?.Invoke(this);
    }
}