using UI;

public interface IHUD : IScreen
{
    void SetPlayer(IPlayerCharacter playerCharacter);
    void SetObjectiveManager(IObjectiveManager objectiveManager);
}