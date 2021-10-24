using Core.Saving;

public class PlayerCharacter : Character, ISaveLoad
{
    private ExperienceManager _experienceManager = new ExperienceManager();

    public ExperienceManager ExperienceManager => _experienceManager;

    protected override void Awake()
    {
        base.Awake();
        Stats.Init(GameConfig.InitialPlayerStats);

        _input = new PlayerInput();
        _experienceManager = new ExperienceManager();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        // _experienceManager.LevelGained += OnLevelUp;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        // _experienceManager.LevelGained -= OnLevelUp;
    }

    protected override void Update()
    {
        base.Update();
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