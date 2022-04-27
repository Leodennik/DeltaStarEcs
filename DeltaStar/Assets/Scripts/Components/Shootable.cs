using Leopotam.Ecs;

namespace DeltaStar.Components
{
    public struct Shootable
    {
        public Weapon weapon;

        public void Shoot()
        {
            weapon.entity.Get<Shoot>();
        }
    }
}