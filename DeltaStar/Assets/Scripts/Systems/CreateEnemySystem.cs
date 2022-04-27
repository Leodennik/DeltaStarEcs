using DeltaStar.Components;
using DeltaStar.Configuration;
using DeltaStar.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.Systems
{
    public class CreateEnemySystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EnemyConfiguration _enemyConfiguration;

        private float _createMinX = -8;
        private float _createMaxX = 8;
        
        private float _createY = 6.0f;

        private float _createMinDelay = 1.0f;
        private float _createMaxDelay = 3.0f;
        private float _createTimer;
        
        public void Init()
        {
            
        }
        
        public void Run()
        {
            if (_createTimer <= 0)
            {
                _createTimer = Random.Range(_createMinDelay, _createMaxDelay);
                
                float x = Random.Range(_createMinX, _createMaxX);
                CreateEnemy(x, _createY);
            }

            _createTimer -= Time.deltaTime;
        }
        
        private void CreateEnemy(float x, float y)
        {
            EcsEntity enemyShipEntity = _world.NewEntity();
            ref Ship ship = ref enemyShipEntity.Get<Ship>();
            ref Enemy enemy = ref enemyShipEntity.Get<Enemy>();
            ref Health health = ref enemyShipEntity.Get<Health>();
            
            ref var movableComponent = ref enemyShipEntity.Get<Movable>();
                
            Vector3 position = new Vector3(x, y, 0);
            
            EnemyParameters enemyParameters = _enemyConfiguration.GetRandomEnemy();
            enemy.minShootDelay = enemyParameters.minShootDelay;
            enemy.maxShootDelay = enemyParameters.maxShootDelay;
            
            ShipView shipView = Object.Instantiate(enemyParameters.prefab, position, Quaternion.identity);
            shipView.entity = enemyShipEntity;
            health.Init(enemyParameters.health);
            
            ship.view = shipView;
            
            movableComponent.transform = shipView.transform;
            movableComponent.direction = new Vector2(0, -1);

            float speed = Random.Range(enemyParameters.minSpeed, enemyParameters.maxSpeed);
            movableComponent.speed = speed;

            AttachWeapon(shipView, enemyShipEntity);
        }
        
        private void AttachWeapon(ShipView shipView, EcsEntity enemyShipEntity)
        {
            WeaponView weaponView = shipView.GetComponentInChildren<WeaponView>();
            var weaponEntity = _world.NewEntity();
            ref Weapon weapon = ref weaponEntity.Get<Weapon>();
            weapon.Init(enemyShipEntity, shipView.GetComponent<Collider2D>(), weaponEntity, weaponView, Vector2.down);

            ref Delay weaponShootDelay = ref weaponEntity.Get<Delay>();
            weaponShootDelay.delayInSeconds = weaponView.shootDelay;

            ref var shootableComponent = ref enemyShipEntity.Get<Shootable>();
            enemyShipEntity.Get<Delay>();
            shootableComponent.weapon = weapon;
        }
    }
}