using DeltaStar.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.Systems
{
    public class MoveSystem : IEcsRunSystem
    {
        private EcsFilter<Movable> _filter;
    
        public void Run()
        {
            foreach (int index in _filter)
            {
                ref var movableComponent = ref _filter.Get1(index);
                movableComponent.transform.position += (Vector3)movableComponent.direction * movableComponent.speed  * Time.deltaTime;
            }
        }
    }
}