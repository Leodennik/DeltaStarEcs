using DeltaStar.Components;
using DeltaStar.Configuration;
using DeltaStar.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.Systems
{
    public class ShipDestroySystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<Ship, Health> filter;
        private GameConfiguration _configuration;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref EcsEntity entity = ref filter.GetEntity(i);
                ref Ship ship = ref filter.Get1(i);
                ref Health health = ref filter.Get2(i);

                if (health.IsZero())
                {
                    CreateExplosion(ship.view.transform.position);
                    
                    Object.Destroy(ship.view.gameObject);
                    entity.Destroy();
                }
            }
        }

        private void CreateExplosion(Vector2 position)
        {
            EcsEntity explosionEntity = _world.NewEntity();
            ref Explosion explosion = ref explosionEntity.Get<Explosion>();
            
            ExplosionView explosionView = Object.Instantiate(_configuration.prefabExplosion, position, Quaternion.identity);
            explosionView.entity = explosionEntity;

            explosion.view = explosionView;
        }
    }
}