using System.Diagnostics;
using Core.FSM;
using Game.Weapons;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class WhiteClownEnemy : EnemyCharacter
{
    public FiniteStateMachine FiniteStateMachine { get; private set; }
    public States State = new States();
    public Fireball FireballPrefab;
    public Transform FireballSpawnPosition;

    [SerializeField] private Animator _animator;

    public WhiteClownAnimator WhiteClownAnimator { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        FiniteStateMachine = new FiniteStateMachine();
        WhiteClownAnimator = new WhiteClownAnimator(_animator);

        State.Idle = new WhiteClownIdleState(this);
        State.Chase = new WhiteClownChaseState(this);
        State.Shoot = new WhiteClownShootState(this);
    }

    protected override void Start()
    {
        base.Start();
        FiniteStateMachine.SetState(State.Idle);
    }

    protected override void Update()
    {
        base.Update();
        FiniteStateMachine.UpdateState();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        FiniteStateMachine.FixedUpdateState();
    }

    public class States
    {
        public WhiteClownIdleState Idle;
        public WhiteClownChaseState Chase;
        public WhiteClownShootState Shoot;
    }
}

public class WhiteClownAnimator
{
    private Animator _animator;

    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Chase = Animator.StringToHash("Chase");
    private static readonly int Shoot = Animator.StringToHash("Shoot");

    public WhiteClownAnimator(Animator animator)
    {
        _animator = animator;
    }

    public void EnterIdleState()
    {
        _animator.SetTrigger(Idle);
    }

    public void EnterChaseState()
    {
        _animator.SetTrigger(Chase);
    }

    public void EnterShootState()
    {
        _animator.SetTrigger(Shoot);
    }
}