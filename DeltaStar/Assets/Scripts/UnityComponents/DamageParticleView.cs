using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.UnityComponents
{
    [RequireComponent(typeof(ParticleSystem))]
    public class DamageParticleView : MonoBehaviour
    {
        public EcsEntity entity;

        // Called from Animation Event on Last Frame
        public void OnAnimationFinished()
        {
            entity.Get<AnimationFinished>();
        }
    }
}