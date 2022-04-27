using DeltaStar.Components;
using DeltaStar.UnityComponents;
using Leopotam.Ecs;

namespace DeltaStar.Systems
{
    public class TakeDamageSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<Ship, TakeDamage, Health> _filter;
        private UI _ui;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(i);
                ref Ship ship = ref _filter.Get1(i);
                ref TakeDamage takeDamage = ref _filter.Get2(i);
                ref Health health = ref _filter.Get3(i);

                health.AddValue(-takeDamage.value);

                if (entity.Has<HealthUi>())
                {
                    ref HealthUi healthUi = ref entity.Get<HealthUi>();
                    healthUi.bar.Set(health.GetValueNormalized());
                }

                entity.Del<TakeDamage>();
            }
        }
    }
}