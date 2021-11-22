using UnityEngine;

namespace Characters.Enemies
{
    public class ParasiteEatState : ParasiteState
    {
        private float _damagePerSecond = 15f;
        private float _pinDuration = 4f;

        public ParasiteEatState(ParasiteEnemy parasite) : base(parasite)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _parasite.ParasiteAnimator.EnterBitingState();
            _parasite.Player.PinDown();
        }

        public override void OnExit()
        {
            base.OnExit();
            _parasite.Player.ReleaseFromPinDown();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            _pinDuration -= Time.deltaTime;
            if (_pinDuration <= 0)
            {
                _parasite.FiniteStateMachine.SetState(_parasite.State.Chase);
            }

            _parasite.Player.Health.TakeDamage(_damagePerSecond * Time.deltaTime);
        }
    }
}