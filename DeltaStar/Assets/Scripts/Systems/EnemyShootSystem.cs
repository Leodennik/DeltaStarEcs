using DeltaStar.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.Systems
{
    public class EnemyShootSystem : IEcsRunSystem
    {
        private EcsFilter<Shootable, Delay, Enemy> _filterEnemyShoot;

        public void Run()
        {
            foreach (int index in _filterEnemyShoot)
            {
                ref Shootable shootable = ref _filterEnemyShoot.Get1(index);
                ref Delay delay = ref _filterEnemyShoot.Get2(index);
                ref Enemy enemy = ref _filterEnemyShoot.Get3(index);

                if (delay.IsReady())
                {
                    shootable.Shoot();
                    delay.delayInSeconds = Random.Range(enemy.minShootDelay, enemy.maxShootDelay);
                    delay.Restart();
                }
            }
        }
    }
}