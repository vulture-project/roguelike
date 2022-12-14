using Gameplay.Core.States;

using Gameplay.Magic.Behaviours;
using Gameplay.Magic.Spells;

using UnityEngine;

namespace Gameplay.Magic.States
{
    [RequireComponent(typeof(Animator), typeof(FirePoint))]
    public class ProjectileCastingState : State
    {
        [SerializeField]
        private ProjectileCastSpell _spell;

        private Animator _animator;
        private int _isCastingProjectileHash;
        private FirePoint _firePoint;
        private Transform _transform;        

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _isCastingProjectileHash = Animator.StringToHash("isCastingProjectile");
            _firePoint = GetComponent<FirePoint>();
            _transform = transform;
        }

        public override void OnEnter()
        {
            _animator.SetBool(_isCastingProjectileHash, true);
        }
    
        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
            _animator.SetBool(_isCastingProjectileHash, false);
        }

        public void ShootProjectile()
        {
            var projectile = Instantiate(_spell.ProjectilePrefab(), _firePoint.Position(), Quaternion.identity);
            projectile.GetComponent<Rigidbody>().velocity = _transform.forward * _spell.Velocity();
        }

        public void ProjectileCastingFinished()
        {
            _stateSwitch.Switch(StateType.Idle);
        }
    }
}