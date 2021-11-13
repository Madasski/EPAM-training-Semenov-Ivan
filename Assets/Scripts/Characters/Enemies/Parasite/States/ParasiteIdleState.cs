using UnityEngine;

namespace Characters.Enemies
{
    public class ParasiteIdleState : ParasiteState
    {
        public ParasiteIdleState(ParasiteEnemy parasite) : base(parasite)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _parasite.ParasiteAnimator.EnterIdleState();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (_parasite.IsPlayerInDetectionRange)
            {
                _parasite.FiniteStateMachine.SetState(_parasite.State.Chase);
            }
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            _parasite.Mover.Move(Vector2.zero);
        }
    }
}