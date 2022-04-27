using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.UnityComponents
{
    public class ExplosionView : MonoBehaviour
    {
        public EcsEntity entity;

        // Called from Animation Event on Last Frame
        public void OnAnimationFinished()
        {
            entity.Get<AnimationFinished>();
        }
    }
}