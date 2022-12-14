using UnityEngine;

namespace Gameplay.Magic.Behaviours
{
    public class FirePoint : MonoBehaviour
    {
        [SerializeField]
        private GameObject _firePoint;

        public Vector3 Position()
        {
            return _firePoint.transform.position;
        }
    }
}