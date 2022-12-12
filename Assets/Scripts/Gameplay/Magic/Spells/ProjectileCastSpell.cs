using UnityEngine;

namespace Gameplay.Magic.Spells
{
    [CreateAssetMenu(fileName = "ProjectileCastSpell", menuName = "Projectile cast spell", order = 51)]
    public class ProjectileCastSpell : ScriptableObject
    {
        [SerializeField]
        private float _damage;

        [SerializeField]
        private GameObject _projectilePrefab;

        [SerializeField]
        private float _velocity;

        public float Damage()
        {
            return _damage;
        }

        public GameObject ProjectilePrefab()
        {
            return _projectilePrefab;
        }

        public float Velocity()
        {
            return _velocity;
        }
    }
}