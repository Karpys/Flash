namespace Flash.StateMachine
{
    public interface IState
    {
        public bool IsFinished { get; }
        public void UpdateState();
        public void OnNextState();
    }
}