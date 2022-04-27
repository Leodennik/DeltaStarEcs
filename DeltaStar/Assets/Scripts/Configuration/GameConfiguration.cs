using DeltaStar.UnityComponents;
using UnityEngine;

namespace DeltaStar.Configuration
{
    [CreateAssetMenu]
    public class GameConfiguration : ScriptableObject
    {
        public int starsCount = 100;

        public ExplosionView prefabExplosion;
        public StarView prefabStar;
        public DamageParticleView prefabDamageParticles;
    }
}