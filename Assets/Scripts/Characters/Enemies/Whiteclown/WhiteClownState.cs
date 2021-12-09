using Core.FSM;

public abstract class WhiteClownState : IState
{
    protected WhiteClownEnemy _clown;

    public WhiteClownState(WhiteClownEnemy clown)
    {
        _clown = clown;
    }

    public virtual void UpdateState()
    {
    }

    public virtual void FixedUpdateState()
    {
    }

    public virtual void OnEnter()
    {
    }

    public virtual void OnExit()
    {
    }
}