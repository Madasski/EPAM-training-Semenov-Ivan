using UnityEngine;

namespace Characters.Enemies
{
    public class ParasiteJumpChargeState : ParasiteState
    {
        private float _chargeTime;

        public ParasiteJumpChargeState(ParasiteEnemy parasite) : base(parasite)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _chargeTime = 1f;
            _parasite.ParasiteAnimator.EnterJumpChargingState();
        }

        public override void UpdateState()
        {
            base.UpdateState();

            _chargeTime -= Time.deltaTime;

            if (_parasite.IsPlayerInDetectionRange == false)
            {
                _parasite.FiniteStateMachine.SetState(_parasite.State.Idle);
            }

            if (_chargeTime <= 0)
            {
                _parasite.FiniteStateMachine.SetState(_parasite.State.Jump);
            }
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
        }
    }
}