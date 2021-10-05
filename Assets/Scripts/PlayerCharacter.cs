using UnityEngine;

public class PlayerCharacter : Character
{
    public int CurrentLevel;
    private ExperienceManager _experienceManager;

    protected override void Awake()
    {
        base.Awake();
        
        _input = new PlayerInput();
        _experienceManager=new ExperienceManager();
        
        CurrentLevel = 1;
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

    public void GainExperience(int amount)
    {
        _experienceManager.GainExperience(amount);
    }
}