using UnityEngine;

public class GameProgression
{
    private PlayerCharacter _player;

    public void SetPlayer(PlayerCharacter playerCharacter)
    {
        _player = playerCharacter;
    }

    public void AddExperienceToPlayer(Character character)
    {
        if(_player == null) return;
        
        Debug.Log("Add exp to player");
        character.OnDie -= AddExperienceToPlayer;
        // _player.GainExperience();
    }
}