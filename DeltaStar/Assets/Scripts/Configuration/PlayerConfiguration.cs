using System;
using DeltaStar.UnityComponents;
using UnityEngine;

namespace DeltaStar.Configuration
{
    [CreateAssetMenu]
    public class PlayerConfiguration : ScriptableObject
    {
        public PlayerParameters[] playerPrefabs;
    }
    
    [Serializable]
    public class PlayerParameters
    {
        public ShipView prefab;
        public float health;
    }
}