using System;
using UnityEngine;

namespace Scripts.Bullets
{
    public class MoverBullet : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Transform _transformBullet;
        private Transform _target;

        public event Action Moved;
        
        private void Awake()
        {
            _transformBullet = transform;
        }

        private void Update()
        {
            if (_target == null || _target.gameObject.activeSelf == false)
            {
                Moved?.Invoke();
                
                return;
            }
            
            _transformBullet.position = Vector3.MoveTowards(_transformBullet.position, _target.position, _speed * Time.deltaTime);
        }
        
        public void SetTarget(Transform target) =>
            _target = target;
    }
}