public class EnemyCharacter : Character
{
    protected override void Awake()
    {
        base.Awake();
        _input = new AIInput();
    }


    protected override void Update()
    {
        // base.Update();
    }
}