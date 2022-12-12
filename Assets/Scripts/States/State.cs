using UnityEngine;

namespace States
{
    public abstract class State : MonoBehaviour
    {
        protected StateType _type;
        protected IStateSwitch _stateSwitch;

        public StateType Type()
        {
            return _type;
        }

        public void SetType(StateType type)
        {
            _type = type;
        }
        
        public void OnAdd(IStateSwitch stateSwitch)
        {
            _stateSwitch = stateSwitch;
        }

        public void OnRemove(IStateSwitch stateSwitch)
        {
            _stateSwitch = null;
        }
        
        public abstract void OnEnter();
    
        public abstract void OnUpdate();

        public abstract void OnExit();
    }
}