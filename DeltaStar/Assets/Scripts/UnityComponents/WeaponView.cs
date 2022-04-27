using System;
using UnityEngine;

namespace DeltaStar.UnityComponents
{
    public class WeaponView : MonoBehaviour
    {
        public BulletView projectilePrefab;
        public float projectileSpeed;
        public int damage;
        public float shootDelay = 0.1f;
        public float energy;
        public float restoreSpeed;
        public AudioSource soundShoot;

        private void Start()
        {
            soundShoot = GetComponent<AudioSource>();
        }

        public void PlayShootSound()
        {
            if (soundShoot != null)
            {
                soundShoot.Play();
            }
        }
    }
}