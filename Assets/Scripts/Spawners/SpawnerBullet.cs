using System;
using Scripts.Bullets;
using UnityEngine;

namespace Scripts.Spawners
{
    public class SpawnerBullet : SpawnerObjects<Bullet>
    {
        public event Action Pooled;
        
        public void Spawn(Transform startPoint, Transform target)
        {
            Bullet bullet = Get();
            bullet.SetTarget(startPoint, target);
        }

        protected override void OnGet(Bullet bullet)
        {
            base.OnGet(bullet);
            bullet.Removed += OnReturnToPool;
        }

        protected override void OnRelease(Bullet bullet)
        {
            bullet.Removed -= OnReturnToPool;
            Pooled?.Invoke();
            base.OnRelease(bullet);
        }

        private void OnReturnToPool(Bullet bullet) =>
            AddToPool(bullet);
    }
}
