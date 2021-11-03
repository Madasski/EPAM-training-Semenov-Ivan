using Madasski.Core;
using UnityEngine;

public class EnemyCharacter : Character
{
    public float DetectionRange;
    public float AttackRange;
    public int experienceForKill;

    [SerializeField] private PlayerCharacter _player;

    public PlayerCharacter Player => _player;

    public bool IsPlayerInDetectionRange
    {
        get
        {
            if (!_player) return false;
            return Vector3.Distance(transform.position, _player.transform.position) <= DetectionRange;
        }
    }

    public bool IsPlayerInAttackRange
    {
        get
        {
            if (!_player) return false;
            return Vector3.Distance(transform.position, _player.transform.position) <= AttackRange;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        Stats.Init(GameConfig.EnemyStats);
        _input = new AIInput(this);
    }

    public void SetPlayer(PlayerCharacter playerCharacter)
    {
        _player = playerCharacter;
    }

    protected override void Die()
    {
        base.Die();
        ObjectPool.Instance.ReturnObjectToPool(this);
    }

    private void Start()
    {
        if (_player)
            LookTarget = _player.transform;
    }

    protected override void Update()
    {
        base.Update();
    }
}