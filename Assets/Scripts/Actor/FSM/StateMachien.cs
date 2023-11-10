using Anchor;

namespace Anchor.Unity.Actor
{
    public class StateMachine<T> where T : class
    {
        private T m_Actor;
        private State<T> m_CurrentState;
        private State<T> m_PreviousState;

        public void Setup(T actor, State<T> entryState)
        {
            m_Actor = actor;
            m_CurrentState = null;
            m_PreviousState = null;

            ChangeState(entryState);
        }

        public void Excute()
        {
            if (m_CurrentState != null)
            {
                m_CurrentState?.Excute(m_Actor);
            }
        }

        public void ChangeState(State<T> newState)
        {
            if (newState == null) return;
            if (m_CurrentState == newState) return;

            if (m_CurrentState != null)
            {
                m_PreviousState = m_CurrentState;
                m_PreviousState.Exit(m_Actor);
            }

            m_CurrentState = newState;
            m_CurrentState.Enter(m_Actor);
        }

        public void ReverToPreviousState()
        {
            ChangeState(m_PreviousState);
        }
    }
}