using Composition;
using Core.Saving;
using Madasski.Skills;
using Madasski.Stats;

public class PlayerCharacter : Character, IPlayerCharacter //, ISaveLoad
{
    private ISaveLoadManager _saveLoadManager;
    private IInput _input;
    private bool _isPinnedDown;

    public IWeaponManager WeaponManager { get; private set; }
    public SkillController SkillController { get; private set; }
    public IExperienceManager ExperienceManager { get; } = new ExperienceManager();

    protected override void Awake()
    {
        base.Awake();
        _saveLoadManager = CompositionRoot.GetSaveLoadManager();
        WeaponManager = GetComponent<IWeaponManager>();

        var playerStats = _saveLoadManager.CurrentSaveData.CharacterStats;
        var initialExperience = _saveLoadManager.CurrentSaveData.PlayerExperience;
        var initialLevel = _saveLoadManager.CurrentSaveData.PlayerLevel;

        ExperienceManager.Init(initialExperience, initialLevel);
        StatsController = new CharacterStatsController(playerStats);
        SkillController = new SkillController(this);

        _input = CompositionRoot.GetUserInput();
    }

    protected override void Update()
    {
        if (_isPinnedDown) return;
        base.Update();

        if (_input.UseWeaponInput)
        {
            WeaponManager.UseCurrentWeapon(StatsController.Power);
        }

        if (_input.ReloadInput)
        {
            WeaponManager.ReloadCurrentWeapon();
        }

        if (_input.ChangeWeaponInput != 0)
        {
            WeaponManager.ChangeWeapon(_input.ChangeWeaponInput);
        }

        for (var skillNumber = 0; skillNumber < 3; skillNumber++)
        {
            if (_input.UseSkillInput[skillNumber] == true)
            {
                SkillController.UseSkill(skillNumber);
                return;
            }
        }
    }

    protected override void FixedUpdate()
    {
        if (_isPinnedDown) return;
        base.FixedUpdate();
        _mover.Move(_input.MovementInput);
        _mover.RotateAt(_input.HorizontalMouseWorldPosition);
    }

    protected override void Die()
    {
        base.Die();
        gameObject.SetActive(false);
    }

    public void Init()
    {
        gameObject.SetActive(true);
        //todo init with starting data
    }

    public void PinDown()
    {
        _isPinnedDown = true;
    }

    public void ReleaseFromPinDown()
    {
        _isPinnedDown = false;
    }
}