using DeltaStar.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.Systems
{
    public class DelaySystem : IEcsRunSystem
    {
        private EcsFilter<Delay> _filter;
    
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref Delay delay = ref _filter.Get1(i);
                delay.timer += Time.deltaTime;
            }
        }
    }
}