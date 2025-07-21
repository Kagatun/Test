using Scripts.Spawners;
using UnityEngine;

namespace Scripts.Players
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private SpawnerBullet _spawnerBullet;

        private Transform _transformAttacker;

        private void Awake()
        {
            _transformAttacker = transform;
        }

        private void OnEnable()
        {
            _spawnerBullet.Pooled += ClearTarget;
        }

        private void OnDisable()
        {
            _spawnerBullet.Pooled -= ClearTarget;
        }

        public void Shoot()
        {
            if (_target == null)
                return;
            
            _spawnerBullet.Spawn(_transformAttacker, _target);
        }
        
        private void ClearTarget() =>
            _target = null;
    }
}