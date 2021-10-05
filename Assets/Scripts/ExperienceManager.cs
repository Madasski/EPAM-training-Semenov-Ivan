using UnityEngine;

public class ExperienceManager
{
    private int _experience = 0;

    public void GainExperience(int amount)
    {
        if(amount<=0) return;
        _experience += amount;

        Debug.Log(_experience);
    }
}