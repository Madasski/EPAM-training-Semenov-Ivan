using UnityEngine;

namespace Characters.Enemies
{
    public class ParasiteJumpState : ParasiteState
    {
        private Vector2 _jumpTargetHorizontalPosition;

        public ParasiteJumpState(ParasiteEnemy parasite) : base(parasite)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _parasite.ParasiteAnimator.EnterJumpAirState();
            _jumpTargetHorizontalPosition = new Vector2(_parasite.Player.Rigidbody.position.x, _parasite.Player.Rigidbody.position.z);
            _parasite.GetComponent<Collider>().isTrigger = true;
        }

        public override void OnExit()
        {
            base.OnExit();
            _parasite.GetComponent<Collider>().isTrigger = false;
        }

        public override void UpdateState()
        {
            base.UpdateState();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();

            var parasiteHorizontalPosition = new Vector2(_parasite.Rigidbody.position.x, _parasite.Rigidbody.position.z);

            if (Vector2.Distance(parasiteHorizontalPosition, _jumpTargetHorizontalPosition) <= .1f)
            {
                var playerHorizontalPosition = new Vector2(_parasite.Player.Rigidbody.position.x, _parasite.Player.Rigidbody.position.z);
                if (Vector2.Distance(playerHorizontalPosition, parasiteHorizontalPosition) < .2f)
                {
                    _parasite.FiniteStateMachine.SetState(_parasite.State.Eat);
                }
                else
                {
                    _parasite.FiniteStateMachine.SetState(_parasite.State.Chase);
                }
            }

            var delta = _jumpTargetHorizontalPosition - parasiteHorizontalPosition;

            if (delta.magnitude > 1)
            {
                delta.Normalize();
            }

            _parasite.Mover.Move(delta);
        }
    }
}