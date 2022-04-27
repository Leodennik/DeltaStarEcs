using System.Collections.Generic;
using DeltaStar.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.Systems
{
    public class BulletSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<Bullet> _filter;
        private ContactFilter2D _contactFilter;
    
        public void Init()
        {
            _contactFilter = new ContactFilter2D();
            _contactFilter.layerMask = LayerMask.GetMask("Wall", "Character");
            _contactFilter.useLayerMask = true;
        }
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref EcsEntity bulletEntity = ref _filter.GetEntity(i);
                ref Bullet bullet = ref _filter.Get1(i);

                List<Collider2D> listColliders = new List<Collider2D>();
                
                Physics2D.OverlapCollider(bullet.selfCollider, _contactFilter, listColliders);

                foreach (Collider2D collider in listColliders)
                {
                    if (collider == bullet.ownerCollider) continue;
                    ref BulletHit bulletHit = ref bulletEntity.Get<BulletHit>();
                    bulletHit.collider = collider;
                    return;
                }

                if (IsOutsideBorders(bullet.view.transform.position))
                {
                    DestroyBullet(bulletEntity, bullet);
                    return;
                }
            }
        }

        private bool IsOutsideBorders(Vector3 position)
        {
            return (position.y < -10 || position.y > 10);
        }
        
        private void DestroyBullet(EcsEntity entity, Bullet bullet)
        {
            Object.Destroy( bullet.view.gameObject);
            entity.Destroy();
        }
    }
}