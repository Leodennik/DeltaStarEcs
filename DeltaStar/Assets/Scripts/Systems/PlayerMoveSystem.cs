using DeltaStar.Components;
using DeltaStar.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.Systems
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private EcsFilter<Movable, InputEvent> _filterPlayerMove;
        private SceneData _sceneData;
        private float _speed = 20;

        public void Run()
        {
            foreach (int index in _filterPlayerMove)
            {
                ref var movableComponent = ref _filterPlayerMove.Get1(index);
                ref var inputComponent   = ref _filterPlayerMove.Get2(index);

                Vector3 screenPoint = _sceneData.camera.ScreenToWorldPoint(inputComponent.position);
                Vector2 currentPosition = movableComponent.transform.position;
                movableComponent.transform.position = Vector2.Lerp(currentPosition, screenPoint, Time.deltaTime*_speed);
            }
        }
    }
}