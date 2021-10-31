using Core.Saving;
using Core.Services;
using Madasski.Skills;

public class PlayerCharacter : Character, ISaveLoad, IService
{
    private readonly ExperienceManager _experienceManager = new ExperienceManager();
    private SkillController _skillController;

    public ExperienceManager ExperienceManager => _experienceManager;
    public SkillController SkillController => _skillController;

    protected override void Awake()
    {
        base.Awake();
        Stats.Init(GameConfig.InitialPlayerStats);
        _skillController = new SkillController(this);

        _input = new PlayerInput();
        ServiceLocator.Instance.Register(this);
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
        base.Update();

        for (var skillNumber = 0; skillNumber < 3; skillNumber++)
        {
            if (_input.UseSkillInput[skillNumber] == true)
            {
                _skillController.UseSkill(skillNumber);
                return;
            }
        }
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
}