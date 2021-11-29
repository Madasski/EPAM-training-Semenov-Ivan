using UnityEngine;

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
            // Debug.Log(newState.ToString());
            _currentState.OnEnter();
        }

        public void UpdateState()
        {
            if (_currentState != null)
            {
                _currentState.UpdateState();
            }
        }

        public void FixedUpdateState()
        {
            if (_currentState != null)
            {
                _currentState.FixedUpdateState();
            }
        }
    }
}