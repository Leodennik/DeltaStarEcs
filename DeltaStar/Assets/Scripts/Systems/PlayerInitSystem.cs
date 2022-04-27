using DeltaStar.Components;
using DeltaStar.Configuration;
using DeltaStar.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private GameConfiguration _gameConfiguration;
        private PlayerConfiguration _playerConfiguration;
        private UI _ui;

        
        public void Init()
        {
            EcsEntity playerShipEntity = _world.NewEntity();
            ref Ship ship = ref playerShipEntity.Get<Ship>();
            playerShipEntity.Get<Player>();
            playerShipEntity.Get<InputEvent>();
            ref Health health = ref playerShipEntity.Get<Health>();
            ref HealthUi heatlthUi = ref playerShipEntity.Get<HealthUi>();

            ref Movable movable = ref playerShipEntity.Get<Movable>();
            //playerShipEntity.Get<CameraTarget>();

            int shipIndex = _ui.screenGame.selectedShipIndex;
            PlayerParameters playerParameters = _playerConfiguration.playerPrefabs[shipIndex];
            ShipView playerView = Object.Instantiate(playerParameters.prefab, Vector3.zero, Quaternion.identity);
            playerView.entity = playerShipEntity;
            health.Init(playerParameters.health);
            heatlthUi.Init(_ui.screenGame.GetHealthBar(), health.GetValueNormalized());
            
            ship.view = playerView;
            movable.transform = playerView.transform;

            AttachWeapon(playerView, playerShipEntity);
        }

        private void AttachWeapon(ShipView playerView, EcsEntity playerShipEntity)
        {
            WeaponView weaponView = playerView.GetComponentInChildren<WeaponView>();
            var weaponEntity = _world.NewEntity();
            ref Weapon weapon = ref weaponEntity.Get<Weapon>();
            ref HealthUi energyUi = ref weaponEntity.Get<HealthUi>();
            
            weapon.Init(playerShipEntity, playerView.GetComponent<Collider2D>(), weaponEntity, weaponView, Vector2.up);
            energyUi.Init(_ui.screenGame.GetEnergyBar(), weapon.energy.GetValueNormalized());

            
            ref Delay delay = ref weaponEntity.Get<Delay>();
            delay.delayInSeconds = weaponView.shootDelay;

            ref Shootable shootable = ref playerShipEntity.Get<Shootable>();
            shootable.weapon = weapon;
        }
    }
}