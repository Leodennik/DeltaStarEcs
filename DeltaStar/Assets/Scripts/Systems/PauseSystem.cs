using DeltaStar.Components;
using DeltaStar.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.Systems
{
    public class PauseSystem : IEcsRunSystem
    {
        private EcsFilter<PauseEvent> _filter;
        private RuntimeData _runtimeData;
        private UI _ui;
    
        public void Run()
        {
            foreach (int i in _filter)
            {
                _filter.GetEntity(i).Del<PauseEvent>();
                _runtimeData.isPaused = !_runtimeData.isPaused;
                Time.timeScale = _runtimeData.isPaused ? 0f : 1f;
                _ui.screenPause.Show(_runtimeData.isPaused);
            }

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = _runtimeData.isPaused;
        }
    }
}