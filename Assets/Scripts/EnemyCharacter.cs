using UnityEngine;

public class EnemyCharacter : Character
{
    public PlayerCharacter Player;
    public float DetectionRange;

    public bool IsPlayerInRange => Vector3.Distance(transform.position, Player.transform.position) <= DetectionRange;

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