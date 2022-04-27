using DeltaStar.Components;
using DeltaStar.Configuration;
using DeltaStar.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.Systems
{
    public class BulletHitSystem : IEcsRunSystem
    {
        private GameConfiguration _configuration;
        private EcsWorld _world;
        private EcsFilter<BulletHit> _filterHit;
        private EcsFilter<Bullet, BulletHit> _filter;
    
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(i);
                ref Bullet bullet = ref _filter.Get1(i);
                ref BulletHit bulletHit = ref _filter.Get2(i);

                ShipView shipView = bulletHit.collider.GetComponent<ShipView>();
                if (shipView != null)
                {
                    ref TakeDamage takeDamage = ref shipView.entity.Get<TakeDamage>();
                    takeDamage.value = bullet.damage;

                    CreateParticle(bullet.view.transform.position);
                }
                
                entity.Del<BulletHit>();
                DestroyBullet(entity, bullet);
            }
        }

        private void CreateParticle(Vector3 position)
        {
            Object.Instantiate(_configuration.prefabDamageParticles, position, Quaternion.identity);
        }

        private void DestroyBullet(EcsEntity entity, Bullet bullet)
        {
            Object.Destroy( bullet.view.gameObject);
            entity.Destroy();
        }
    }
}