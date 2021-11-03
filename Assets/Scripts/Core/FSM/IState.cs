namespace Core.FSM
{
    public interface IState
    {
        void UpdateState();
        void OnEnter();
        void OnExit();
    }
}