using UnityEngine;

public class WhiteClownShootState : WhiteClownState
{
    private float shotDelay = .8f;
    private float timeSinceLastShot = 0;

    public WhiteClownShootState(WhiteClownEnemy clown) : base(clown)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _clown.WhiteClownAnimator.EnterShootState();
        SpawnFireball();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_clown.IsPlayerInDetectionRange == false)
        {
            _clown.FiniteStateMachine.SetState(_clown.State.Idle);
        }

        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= shotDelay)
        {
            SpawnFireball();
            timeSinceLastShot = 0;
        }
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        _clown.Mover.RotateAtTransform(_clown.Player.Mover.Transform);
    }

    private void SpawnFireball()
    {
        Object.Instantiate(_clown.FireballPrefab, _clown.FireballSpawnPosition.position, _clown.transform.rotation);
    }
}