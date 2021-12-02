using Madasski.Core;
using UnityEngine;

public class EnemyCharacter : Character, IEnemyCharacter
{
    public float DetectionRange;
    public float AttackRange;
    public int experienceForKill;

    private IPlayerCharacter _player;

    public IPlayerCharacter Player => _player;

    public bool IsPlayerInDetectionRange
    {
        get
        {
            if (_player == null) return false;
            return Vector3.Distance(transform.position, _player.Mover.Transform.position) <= DetectionRange;
        }
    }

    public bool IsPlayerInAttackRange
    {
        get
        {
            if (_player == null) return false;
            return Vector3.Distance(transform.position, _player.Mover.Transform.position) <= AttackRange;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        Stats.Init(GameConfig.EnemyStats);
    }

    public void SetPlayer(PlayerCharacter playerCharacter)
    {
        _player = playerCharacter;
        _player.Died += OnPlayerDied;
    }

    protected virtual void OnPlayerDied(Character player)
    {
        _player.Died -= OnPlayerDied;
    }

    protected override void Die()
    {
        base.Die();
        ObjectPool.Instance.ReturnObjectToPool(this);
    }

    protected virtual void Start()
    {
        if (_player != null)
            LookTarget = _player.Mover.Transform;
    }
}