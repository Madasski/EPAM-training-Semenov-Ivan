using UnityEngine;

namespace Characters.Enemies
{
    public class ParasiteChaseState : ParasiteState
    {
        private Vector2 _moveDirection;

        public ParasiteChaseState(ParasiteEnemy parasite) : base(parasite)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _parasite.ParasiteAnimator.EnterRunningState();
        }

        public override void UpdateState()
        {
            base.UpdateState();

            var moveX = _parasite.Player.Rigidbody.position.x - _parasite.Rigidbody.position.x;
            var moveZ = _parasite.Player.Rigidbody.position.z - _parasite.Rigidbody.position.z;

            _moveDirection = new Vector2(moveX, moveZ);
            if (_moveDirection.magnitude > 1)
            {
                _moveDirection.Normalize();
            }

            if (_parasite.IsPlayerInAttackRange)
            {
                _parasite.FiniteStateMachine.SetState(_parasite.State.Attack);
            }

            if (_parasite.IsPlayerInDetectionRange == false)
            {
                _parasite.FiniteStateMachine.SetState(_parasite.State.Idle);
            }
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            _parasite.Mover.Move(_moveDirection);
            _parasite.Mover.RotateAtTransform(_parasite.Player.transform);
        }
    }
}