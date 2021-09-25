using UnityEngine;

public class EnemyCharacter : Character
{
    public PlayerCharacter Player;
    public float DetectionRange;
    public float AttackRange;

    public bool IsPlayerInDetectionRange
    {
        get
        {
            if (!Player) return false;
            return Vector3.Distance(transform.position, Player.transform.position) <= DetectionRange;
        }
    }

    public bool IsPlayerInAttackRange
    {
        get
        {
            if (!Player) return false;
            return Vector3.Distance(transform.position, Player.transform.position) <= AttackRange;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        _input = new AIInput(this);
    }

    private void Start()
    {
        LookTarget = Player.transform;
    }

    protected override void Update()
    {
        base.Update();
    }
}