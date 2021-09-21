public class PlayerCharacter : Character
{
    protected override void Awake()
    {
        base.Awake();
        _input = new PlayerInput();
    }
}