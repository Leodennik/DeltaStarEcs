using DeltaStar.Components;
using DeltaStar.Configuration;
using DeltaStar.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.Systems
{
    public class InitStarsSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private GameConfiguration _gameConfiguration;
        private SceneData _sceneData;
        
        public void Init()
        {
            for (int i = 0; i < _gameConfiguration.starsCount; i++)
            {
                Vector2 position = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
                Vector2 worldPosition = _sceneData.camera.ScreenToWorldPoint(position);
                float size = Random.Range(0.2f, 1.0f);
                Vector2 scale = new Vector2(size, size);
                
                CreateStar(worldPosition, scale);
            }
        }

        private void CreateStar(Vector2 position, Vector2 scale)
        {
            EcsEntity starEntity = _world.NewEntity();
            ref Star star = ref starEntity.Get<Star>();
                
            StarView starView = Object.Instantiate(_gameConfiguration.prefabStar, position, Quaternion.identity);
            starView.transform.localScale = scale;
        }
    }
}