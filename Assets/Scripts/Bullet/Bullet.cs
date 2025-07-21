using System;
using System.Collections;
using Scripts.Players;
using UnityEngine;

namespace Scripts.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _effect;
        [SerializeField] private MoverBullet _moverBullet;
        [SerializeField] private LayerMask _layer;

        private Transform _transform;
        private WaitForSeconds _wait;
        private float _timeRemove = 0.4f;

        public event Action<Bullet> Removed;

        private void Awake()
        {
            _wait = new WaitForSeconds(_timeRemove);
            _transform = transform;
        }

        private void OnEnable()
        {
            _moverBullet.Moved += OnRemove;
        }

        private void OnDisable()
        {
            _moverBullet.Moved -= OnRemove;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.transform.TryGetComponent(out Player player) || (_layer.value & (1 << player.gameObject.layer)) == 0)
                return;
            
            Destroy(player.gameObject);
            StartCoroutine(StartRemove());
        }

        public void SetTarget(Transform start, Transform target)
        {
            _transform.position = start.position;
            _moverBullet.enabled = true;
            _moverBullet.SetTarget(target);
        }

        private IEnumerator StartRemove()
        {
            _effect.gameObject.SetActive(true);
            _moverBullet.enabled = false;
            
            yield return _wait;

            Removed?.Invoke(this);
        }

        private void OnRemove() =>
            Removed?.Invoke(this);
    }
}