namespace States
{
    public interface IStateSwitch
    {
        public void Switch(StateType type);

        public void SetTag(State state, StateType type);

        public void AddState(State state);

        public void RemoveState(State state);
    }
}