using UnityEngine;

namespace States
{
    public class CastingSelfBuffState : State
    {
        [SerializeField] private GameObject selfBuffPrefab;

        private Animator _animator;
        private int _isCastingSelfBuffHash;

        private void Start()
        {
            _animator = gameObject.GetComponent<Animator>();
            _isCastingSelfBuffHash = Animator.StringToHash("isCastingSelfBuff");
        }

        public override void OnEnter()
        {
            _animator.SetBool(_isCastingSelfBuffHash, true);
        }
    
        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
            _animator.SetBool(_isCastingSelfBuffHash, false);
        }

        public void SelfBuff()
        {
        }

        public void SelfBuffCastingFinished()
        {
            _stateSwitch.Switch(StateType.Idle);
        }
    }
}