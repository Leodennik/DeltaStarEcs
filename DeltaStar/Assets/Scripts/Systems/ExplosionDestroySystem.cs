using DeltaStar.Components;
using DeltaStar.Configuration;
using DeltaStar.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.Systems
{
    public class ExplosionDestroySystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<Explosion, AnimationFinished> _filter;
        private GameConfiguration _configuration;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(i);
                ref Explosion explosion = ref _filter.Get1(i);

                Object.Destroy(explosion.view.gameObject);
                entity.Destroy();
            }
        }
    }
}