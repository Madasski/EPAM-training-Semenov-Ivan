public class Enemy : Character
{
    protected override void Awake()
    {
        base.Awake();
        _input = new AIInput();
    }
}