using DeltaStar.UnityComponents;
using UnityEngine;

namespace DeltaStar.Components
{
    public struct Bullet
    {
        public BulletView view;          // To destroy  
        public Collider2D selfCollider;  // To check self collision with others
        public Collider2D ownerCollider; // To ignore owner
        public int damage;
    }
}