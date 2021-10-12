using UnityEngine;

public class PlayerCharacter : Character
{
    private ExperienceManager _experienceManager = new ExperienceManager();

    public ExperienceManager ExperienceManager => _experienceManager;

    protected override void Awake()
    {
        base.Awake();

        _input = new PlayerInput();
        _experienceManager = new ExperienceManager();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _experienceManager.LevelGained += OnLevelUp;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _experienceManager.LevelGained -= OnLevelUp;
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

    private void OnLevelUp()
    {
        Debug.Log("Level up");
        Health.Restore();
        Debug.Log("Health restored");
    }
}