using DeltaStar.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UIElements;
using InputEvent = DeltaStar.Components.InputEvent;

namespace DeltaStar.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<InputEvent> _filterInputEvents;
        private RuntimeData _runtimeData;
        
        public void Run()
        {
            if (!_runtimeData.isPaused)
            {
                foreach (int index in _filterInputEvents)
                {
                    ref var inputEvent = ref _filterInputEvents.Get1(index);
                    inputEvent.position = Input.mousePosition;
                    inputEvent.isShoot = Input.GetMouseButton((int) MouseButton.LeftMouse);
                } 
            }
 

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _world.NewEntity().Get<PauseEvent>();
            }
        }
    }
}