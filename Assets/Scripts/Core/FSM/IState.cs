namespace Core.FSM
{
    public interface IState
    {
        void UpdateState();
        void FixedUpdateState();
        void OnEnter();
        void OnExit();
    }
}