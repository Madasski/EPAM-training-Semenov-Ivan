using Core.Saving;
using Core.Services;
using Madasski.Skills;

public class PlayerCharacter : Character, ISaveLoad 
{
    private readonly ExperienceManager _experienceManager = new ExperienceManager();
    private SkillController _skillController;
    private WeaponManager _weaponManager;
    private IInput _input;
    private bool _isPinnedDown;

    public ExperienceManager ExperienceManager => _experienceManager;
    public SkillController SkillController => _skillController;
    public WeaponManager WeaponManager => _weaponManager;

    protected override void Awake()
    {
        base.Awake();
        _weaponManager = GetComponent<WeaponManager>();
        Stats.Init(GameConfig.InitialPlayerStats);
        _skillController = new SkillController(this);

        _input = new PlayerInput();
        // ServiceLocator.Instance.Register(this);
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
        _input.Read();

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
        Destroy(gameObject);
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