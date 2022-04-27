using DeltaStar.Components;
using Leopotam.Ecs;

namespace DeltaStar.Systems
{
    public class PlayerShootSystem : IEcsRunSystem
    {
        private EcsFilter<Shootable, InputEvent> _filterPlayerShoot;

        public void Run()
        {
            foreach (int index in _filterPlayerShoot)
            {
                var weaponComponent = _filterPlayerShoot.Get1(index);
                var inputComponent   = _filterPlayerShoot.Get2(index);

                if (inputComponent.isShoot)
                {
                    weaponComponent.Shoot();
                }
                //movableComponent.transform.position += (Vector3)inputComponent.direction * movableComponent.moveSpeed  * Time.deltaTime;
            }
        }
    }
}