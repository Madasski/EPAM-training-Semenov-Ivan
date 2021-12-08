using Core.FSM;

namespace Characters.Enemies
{
    public abstract class ParasiteState : IState
    {
        protected ParasiteEnemy _parasite;

        protected ParasiteState(ParasiteEnemy parasite)
        {
            _parasite = parasite;
        }

        public virtual void UpdateState()
        {
        }

        public virtual void FixedUpdateState()
        {
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
        }
    }
}