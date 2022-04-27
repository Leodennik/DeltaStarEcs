using DeltaStar.Components;
using DeltaStar.Configuration;
using DeltaStar.Systems;
using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.UnityComponents {
    sealed class EcsStartup : MonoBehaviour {
        private EcsWorld _world;
        private EcsSystems _systems;
        private RuntimeData _runtimeData;
        
        public PlayerConfiguration playerConfiguration;
        public GameConfiguration gameConfiguration;
        public EnemyConfiguration enemyConfiguration;
        public SceneData sceneData;
        public UI ui;

        void Awake () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            _runtimeData = new RuntimeData();
            
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                // register your systems here, for example:
                .Add (new PlayerInitSystem())
                .Add (new InitStarsSystem())
                .Add (new CreateEnemySystem())
                .Add (new SetCameraSystem())
                .Add (new PlayerInputSystem())
                .Add (new PlayerMoveSystem())
                .Add (new MoveSystem())
                .Add (new PlayerShootSystem())
                .Add (new EnemyShootSystem())
                .Add (new WeaponShootSystem())
                .Add (new DelaySystem())
                .Add (new EnemySystem())
                .Add (new BulletSystem())
                .Add (new BulletHitSystem())
                .Add (new TakeDamageSystem())
                .Add (new ShipDestroySystem())
                .Add (new ExplosionDestroySystem())
                .Add (new WeaponEnergySystem())
                .Add (new PauseSystem())
                
                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()
                
                // inject service instances here (order doesn't important), for example:
                .Inject (playerConfiguration)
                .Inject (gameConfiguration)
                .Inject (enemyConfiguration)
                .Inject (_runtimeData)
                .Inject (sceneData)
                .Inject (ui)
                // .Inject (new NavMeshSupport ())
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}