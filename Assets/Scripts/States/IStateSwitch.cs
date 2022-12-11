namespace States
{
    public interface IStateSwitch
    {
        public void SwitchTo<TState>() where TState : State;
    }   
}