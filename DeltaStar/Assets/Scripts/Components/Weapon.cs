using System;
using DeltaStar.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace DeltaStar.Components
{
    public struct Weapon
    {
        public EcsEntity entity;
        public EcsEntity ownerEntity;
        public WeaponView view;
        public Collider2D ownerCollider;
        public Vector2 direction;
        public Health energy;

        public void Init(EcsEntity ownerEntity, Collider2D ownerCollider, EcsEntity weaponEntity, WeaponView weaponView, Vector2 direction)
        {
            this.ownerEntity = ownerEntity;
            this.ownerCollider = ownerCollider;
            
            entity = weaponEntity;
            view   = weaponView;

            energy = new Health();
            energy.Init(weaponView.energy);
            
            this.direction        = direction;
        }
    }
}