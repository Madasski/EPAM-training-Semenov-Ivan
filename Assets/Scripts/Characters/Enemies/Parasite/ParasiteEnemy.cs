using Core.FSM;
using UnityEngine;

namespace Characters.Enemies
{
    public class ParasiteEnemy : EnemyCharacter
    {
        public States State = new States();

        [SerializeField] private Animator _animator;

        public FiniteStateMachine FiniteStateMachine { get; private set; }
        public ParasiteAnimator ParasiteAnimator { get; private set; }

        protected override void OnEnable()
        {
            base.OnEnable();

            // Player.Died += OnPlayerDied;
            ParasiteAnimator = new ParasiteAnimator(_animator);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            // Player.Died -= OnPlayerDied;
        }

        protected override void OnPlayerDied(ICharacter player)
        {
            base.OnPlayerDied(player);
            FiniteStateMachine.SetState(State.Idle);
        }

        protected override void Start()
        {
            base.Start();

            FiniteStateMachine = new FiniteStateMachine();
            State.Idle = new ParasiteIdleState(this);
            State.Chase = new ParasiteChaseState(this);
            State.JumpCharge = new ParasiteJumpChargeState(this);
            State.Jump = new ParasiteJumpState(this);
            State.Eat = new ParasiteEatState(this);

            FiniteStateMachine.SetState(State.Idle);
        }

        protected override void Update()
        {
            base.Update();
            if (Player == null && FiniteStateMachine.CurrentState != State.Idle)
            {
                FiniteStateMachine.SetState(State.Idle);
            }

            FiniteStateMachine.UpdateState();
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            FiniteStateMachine.FixedUpdateState();
        }

        public class States
        {
            public ParasiteIdleState Idle;
            public ParasiteChaseState Chase;
            public ParasiteJumpChargeState JumpCharge;
            public ParasiteJumpState Jump;
            public ParasiteEatState Eat;
        }
    }

    public class ParasiteAnimator
    {
        private Animator _animator;
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Running = Animator.StringToHash("Running");
        private static readonly int JumpCharging = Animator.StringToHash("JumpCharging");
        private static readonly int JumpAir = Animator.StringToHash("JumpAir");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Biting = Animator.StringToHash("Biting");

        public ParasiteAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void EnterIdleState()
        {
            _animator.SetTrigger(Idle);
        }

        public void EnterRunningState()
        {
            _animator.SetTrigger(Running);
        }

        public void EnterJumpAirState()
        {
            _animator.SetTrigger(JumpAir);
        }

        public void EnterJumpChargingState()
        {
            _animator.SetTrigger(JumpCharging);
        }

        public void EnterAttackState()
        {
            _animator.SetTrigger(Attack);
        }

        public void EnterBitingState()
        {
            _animator.SetTrigger(Biting);
        }
    }
}