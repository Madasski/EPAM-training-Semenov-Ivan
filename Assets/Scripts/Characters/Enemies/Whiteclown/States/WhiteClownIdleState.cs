using UnityEngine;

public class WhiteClownIdleState : WhiteClownState
{
    public WhiteClownIdleState(WhiteClownEnemy clown) : base(clown)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _clown.WhiteClownAnimator.EnterIdleState();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_clown.IsPlayerInDetectionRange)
        {
            _clown.FiniteStateMachine.SetState(_clown.State.Chase);
        }
    }
}