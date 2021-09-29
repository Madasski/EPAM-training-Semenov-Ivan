using UnityEngine;

public class PlayerCharacter : Character
{
    protected override void Awake()
    {
        base.Awake();
        _input = new PlayerInput();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}