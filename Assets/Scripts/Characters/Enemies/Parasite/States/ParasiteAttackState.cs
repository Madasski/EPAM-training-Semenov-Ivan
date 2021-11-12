using UnityEngine;

namespace Characters.Enemies
{
    public class ParasiteAttackState : ParasiteState
    {
        public enum State
        {
            JumpCharging,
            Jumping,
            Land,
            EatEnemy
        }

        private State _state;
        private float _chargeTime = 1f;
        private Vector2 _jumpTargetPosition;
        private float _damagePerSecond= 5f;

        public ParasiteAttackState(ParasiteEnemy parasite) : base(parasite)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _state = State.JumpCharging;
            _parasite.ParasiteAnimator.EnterJumpChargingState();
        }

        public override void UpdateState()
        {
            base.UpdateState();

            if (_state == State.JumpCharging)
            {
                _chargeTime -= Time.deltaTime;
                if (_chargeTime <= 0)
                {
                    _state = State.Jumping;
                    _parasite.ParasiteAnimator.EnterJumpAirState();
                    _jumpTargetPosition = new Vector2(_parasite.Player.Rigidbody.position.x, _parasite.Player.Rigidbody.position.z);
                    _parasite.GetComponent<Collider>().isTrigger = true;
                }
            }

            // if (_parasite.IsPlayerInAttackRange == false)
            // {
            //     _parasite.FiniteStateMachine.SetState(_parasite.State.Idle);
            // }
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            switch (_state)
            {
                case State.JumpCharging:
                    _parasite.Mover.Move(Vector2.zero);
                    break;

                case State.Jumping:
                    var moveX = _jumpTargetPosition.x - _parasite.Rigidbody.position.x;
                    var moveZ = _jumpTargetPosition.y - _parasite.Rigidbody.position.z;

                    var moveDirection = new Vector2(moveX, moveZ);
                    if (moveDirection.magnitude > 1)
                    {
                        moveDirection.Normalize();
                    }

                    _parasite.Mover.Move(moveDirection);
                    _parasite.Mover.RotateAtTransform(_parasite.Player.transform);

                    if (Vector2.Distance(new Vector2(_parasite.Rigidbody.position.x, _parasite.Rigidbody.position.y), _jumpTargetPosition) >= .1f)
                    {
                        _state = State.Land;
                    }

                    break;

                case State.Land:
                    if (Vector3.Distance(_parasite.Rigidbody.position, _parasite.Player.Rigidbody.position) <= .1f)
                    {
                        _state = State.EatEnemy;
                        _parasite.ParasiteAnimator.EnterBitingState();
                    }
                    else
                    {
                        _state = State.JumpCharging;
                    }

                    break;

                case State.EatEnemy:
                    _parasite.Player.Health.TakeDamage(_damagePerSecond*Time.deltaTime);
                    _parasite.Mover.Move(Vector2.zero);
                    
                    break;
            }
        }
    }
}