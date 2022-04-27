using DeltaStar.Components;
using DeltaStar.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.Systems
{
    public class WeaponEnergySystem : IEcsRunSystem
    {
        private EcsFilter<Weapon> _filter;
        private UI _ui;
    
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(i);
                ref Weapon weapon = ref _filter.Get1(i);

                if (!weapon.energy.IsMaxValue())
                {
                    weapon.energy.AddValue(weapon.view.restoreSpeed * Time.deltaTime);

                    if (entity.Has<HealthUi>())
                    {
                        ref HealthUi weaponUi = ref entity.Get<HealthUi>();
                        weaponUi.bar.Set(weapon.energy.GetValueNormalized());
                    }
                }
            }
        }
    }
}