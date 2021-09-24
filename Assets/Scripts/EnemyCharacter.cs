using UnityEngine;

public class EnemyCharacter : Character
{
    public PlayerCharacter Player;
    public float DetectionRange;
    public float AttackRange;

    public bool IsPlayerInDetectionRange => Vector3.Distance(transform.position, Player.transform.position) <= DetectionRange;
    public bool IsPlayerInAttackRange => Vector3.Distance(transform.position, Player.transform.position) <= AttackRange;

    protected override void Awake()
    {
        base.Awake();
        _input = new AIInput(this);
    }

    protected override void Update()
    {
        base.Update();
    }
}