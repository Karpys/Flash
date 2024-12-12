namespace Flash.StateMachine
{
    using System.Collections.Generic;

    public class LoopStateMachine
    {
        private List<IState> m_StateLoop = new List<IState>();
        private IState m_CurrentState = null;
        private int m_CurrentStateId = 0;
        public LoopStateMachine(List<IState> states)
        {
            m_StateLoop = new List<IState>();
        }
        
        public void Update()
        {
            m_CurrentState.UpdateState();

            if (m_CurrentState.IsFinished)
            {
                m_CurrentState.OnNextState();
                NextState();
            }
        }

        private void NextState()
        {
            m_CurrentStateId++;
            if (m_CurrentStateId >= m_StateLoop.Count)
                m_CurrentStateId = 0;
            m_CurrentState = m_StateLoop[m_CurrentStateId];
        }
    }
}