namespace Core.FSM
{
    public class FiniteStateMachine
    {
        private IState _currentState;

        public void SetState(IState newState)
        {
            if (_currentState != null)
            {
                _currentState.OnExit();
            }

            _currentState = newState;
            _currentState.OnEnter();
        }

        public void UpdateState()
        {
            if (_currentState != null)
            {
                _currentState.UpdateState();
            }
        }
    }
}