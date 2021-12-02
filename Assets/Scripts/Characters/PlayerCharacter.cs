using Composition;
using Core.Saving;
using Madasski.Skills;

public class PlayerCharacter : Character, IPlayerCharacter //, ISaveLoad
{
    private readonly ExperienceManager _experienceManager = new ExperienceManager();
    private SkillController _skillController;
    private IWeaponManager _weaponManager;
    private IInput _input;
    private bool _isPinnedDown;

    public ExperienceManager ExperienceManager => _experienceManager;
    public SkillController SkillController => _skillController;
    public IWeaponManager WeaponManager => _weaponManager;

    protected override void Awake()
    {
        base.Awake();
        _weaponManager = GetComponent<IWeaponManager>();
        Stats.Init(GameConfig.InitialPlayerStats);
        _skillController = new SkillController(this);

        _input = CompositionRoot.GetUserInput();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void Update()
    {
        if (_isPinnedDown) return;
        base.Update();

        if (_input.UseWeaponInput)
        {
            _weaponManager.UseCurrentWeapon(Stats.Power);
        }

        if (_input.ReloadInput)
        {
            _weaponManager.ReloadCurrentWeapon();
        }

        if (_input.ChangeWeaponInput != 0)
        {
            _weaponManager.ChangeWeapon(_input.ChangeWeaponInput);
        }

        for (var skillNumber = 0; skillNumber < 3; skillNumber++)
        {
            if (_input.UseSkillInput[skillNumber] == true)
            {
                _skillController.UseSkill(skillNumber);
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
        // Destroy(gameObject);
        // Debug.Log("Is Alive");
    }

    public void Save(GameData gameData)
    {
        Stats.Save(gameData);
        _experienceManager.Save(gameData);
    }

    public void Load(GameData gameData)
    {
        Stats.Load(gameData);
        _experienceManager.Load(gameData);
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