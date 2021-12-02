using UnityEngine;

namespace Characters.Enemies
{
    public class ParasiteJumpState : ParasiteState
    {
        private Vector2 _horizontalJumpTargetPosition;

        public ParasiteJumpState(ParasiteEnemy parasite) : base(parasite)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _parasite.ParasiteAnimator.EnterJumpAirState();
            _horizontalJumpTargetPosition = new Vector2(_parasite.Player.Mover.Transform.position.x, _parasite.Player.Mover.Transform.position.z);
            // _parasite.GetComponent<Collider>().isTrigger = true;
        }

        public override void OnExit()
        {
            base.OnExit();
            // _parasite.GetComponent<Collider>().isTrigger = false;
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();

            var parasiteHorizontalPosition = new Vector2(_parasite.Rigidbody.position.x, _parasite.Rigidbody.position.z);

            if (Vector2.Distance(parasiteHorizontalPosition, _horizontalJumpTargetPosition) <= .2f)
            {
                var playerHorizontalPosition = new Vector2(_parasite.Player.Mover.Transform.position.x, _parasite.Player.Mover.Transform.position.z);
                if (Vector2.Distance(playerHorizontalPosition, parasiteHorizontalPosition) < .7f)
                {
                    _parasite.FiniteStateMachine.SetState(_parasite.State.Eat);
                }
                else
                {
                    _parasite.FiniteStateMachine.SetState(_parasite.State.Chase);
                }
            }

            var movementDelta = _horizontalJumpTargetPosition - parasiteHorizontalPosition;

            if (movementDelta.magnitude > 1)
            {
                movementDelta.Normalize();
            }

            _parasite.Mover.Move(movementDelta);
            _parasite.Mover.RotateAt(_horizontalJumpTargetPosition);
        }
    }
}