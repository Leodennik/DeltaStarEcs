using System;
using DeltaStar.UnityComponents;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DeltaStar.Configuration
{
    [CreateAssetMenu]
    public class EnemyConfiguration : ScriptableObject
    {
        public EnemyParameters[] arrayEnemies;

        public EnemyParameters GetRandomEnemy()
        {
            int sum = 0;
            for (int i = 0; i < arrayEnemies.Length; i++)
            {
                sum += arrayEnemies[i].probability;
            }

            int result = Random.Range(0, sum);
            sum = 0;
            for (int i = 0; i < arrayEnemies.Length; i++)
            {
                sum += arrayEnemies[i].probability;
                if (result <= sum)
                {
                    return arrayEnemies[i];
                }
            }

            return null;
        }
    }

    [Serializable]
    public class EnemyParameters
    {
        public ShipView prefab;
        public int probability;
        public float health;
        public float minSpeed;
        public float maxSpeed;
        public float minShootDelay;
        public float maxShootDelay;
    }
}