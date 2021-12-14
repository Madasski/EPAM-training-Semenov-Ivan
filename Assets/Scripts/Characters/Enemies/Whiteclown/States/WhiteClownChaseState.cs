using UnityEngine;

public class WhiteClownChaseState : WhiteClownState
{
    private Vector2 _moveDirection;

    public WhiteClownChaseState(WhiteClownEnemy clown) : base(clown)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _clown.WhiteClownAnimator.EnterChaseState();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        var moveX = _clown.Player.Mover.Transform.position.x - _clown.Rigidbody.position.x;
        var moveZ = _clown.Player.Mover.Transform.position.z - _clown.Rigidbody.position.z;

        _moveDirection = new Vector2(moveX, moveZ);
        if (_moveDirection.magnitude > 1)
        {
            _moveDirection.Normalize();
        }

        if (_clown.IsPlayerInAttackRange)
        {
            _clown.FiniteStateMachine.SetState(_clown.State.Shoot);
            return;
        }

        if (_clown.IsPlayerInDetectionRange == false)
        {
            _clown.FiniteStateMachine.SetState(_clown.State.Idle);
        }
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        _clown.Mover.Move(_moveDirection);
        _clown.Mover.RotateAtTransform(_clown.Player.Mover.Transform);
    }
}