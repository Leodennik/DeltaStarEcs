using DeltaStar.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.Systems
{
    public class EnemySystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<Enemy, Ship> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref EcsEntity enemyEntity = ref _filter.GetEntity(i);
                ref Ship ship = ref _filter.Get2(i);

                if (IsOutsideBorders(ship.view.transform.position))
                {
                    DestroyBullet(enemyEntity, ship);
                    return;
                }
            }
        }

        private bool IsOutsideBorders(Vector3 position)
        {
            return (position.y < -10 || position.y > 10);
        }
        
        private void DestroyBullet(EcsEntity entity, Ship ship)
        {
            Object.Destroy(ship.view.gameObject);
            entity.Destroy();
        }
    }
}