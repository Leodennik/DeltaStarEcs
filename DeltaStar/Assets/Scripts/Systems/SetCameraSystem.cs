using DeltaStar.UnityComponents;
using Leopotam.Ecs;

namespace DeltaStar.Systems
{
    public class SetCameraSystem : IEcsRunSystem
    {
        private SceneData _sceneData;
        
        public void Run()
        {
            // follow position of player ship
            //_sceneData.camera.orthographicSize = 10;
        }
    }
}