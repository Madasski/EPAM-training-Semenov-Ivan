﻿using Core.FSM;
using UnityEngine;

namespace Characters.Enemies
{
    public class ParasiteEnemy : EnemyCharacter
    {
        public States State = new States();

        [SerializeField] private Animator _animator;
        private FiniteStateMachine _finiteStateMachine;
        private ParasiteAnimator _parasiteAnimator;

        public FiniteStateMachine FiniteStateMachine => _finiteStateMachine;
        public ParasiteAnimator ParasiteAnimator => _parasiteAnimator;

        protected override void OnEnable()
        {
            base.OnEnable();

            // Player.Died += OnPlayerDied;
            _parasiteAnimator = new ParasiteAnimator(_animator);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            // Player.Died -= OnPlayerDied;
        }

        protected override void OnPlayerDied(ICharacter player)
        {
            base.OnPlayerDied(player);
            _finiteStateMachine.SetState(State.Idle);
        }

        protected override void Start()
        {
            base.Start();

            _finiteStateMachine = new FiniteStateMachine();
            State.Idle = new ParasiteIdleState(this);
            State.Chase = new ParasiteChaseState(this);
            State.JumpCharge = new ParasiteJumpChargeState(this);
            State.Jump = new ParasiteJumpState(this);
            State.Eat = new ParasiteEatState(this);

            _finiteStateMachine.SetState(State.Idle);
        }

        protected override void Update()
        {
            base.Update();
            if (Player == null && _finiteStateMachine.CurrentState != State.Idle)
            {
                _finiteStateMachine.SetState(State.Idle);
            }

            _finiteStateMachine.UpdateState();
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            _finiteStateMachine.FixedUpdateState();
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