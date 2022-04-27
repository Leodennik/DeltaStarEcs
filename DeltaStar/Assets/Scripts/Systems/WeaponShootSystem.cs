using DeltaStar.Components;
using DeltaStar.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.Systems
{
    public class WeaponShootSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<Weapon, Delay, Shoot> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(i);
                ref Weapon weapon = ref _filter.Get1(i);
                ref Delay delay = ref _filter.Get2(i);

                if (delay.IsReady()) // Internal shoot delay
                {
                    if (weapon.energy.GetValue() >= 1)
                    {
                        CreateBullet(weapon);
                        weapon.energy.AddValue(-1);
                        weapon.view.PlayShootSound();
                        delay.Restart();
                    }
                    
                    if (entity.Has<HealthUi>())
                    {
                        ref HealthUi weaponUi = ref entity.Get<HealthUi>();
                        weaponUi.bar.Set(weapon.energy.GetValueNormalized());
                    }
                }
                entity.Del<Shoot>();
            }
        }
        
        private void CreateBullet(Weapon weapon)
        {
            EcsEntity bulletEntity = _world.NewEntity();
            ref Bullet bullet = ref bulletEntity.Get<Bullet>();
            ref var movableComponent = ref bulletEntity.Get<Movable>();

            var muzzlePosition = weapon.view.transform.position;
            Vector3 position = new Vector3(muzzlePosition.x, muzzlePosition.y, 0);
                
            BulletView bulletView = Object.Instantiate(weapon.view.projectilePrefab, position, Quaternion.identity);
            movableComponent.transform = bulletView.transform;
            movableComponent.direction = weapon.direction;
            movableComponent.speed = weapon.view.projectileSpeed;

            bullet.selfCollider = bulletView.GetComponent<Collider2D>();
            bullet.ownerCollider = weapon.ownerCollider;
            bullet.view = bulletView;
            bullet.damage = weapon.view.damage;
        }
    }
}