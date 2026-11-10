using System;
using Core.Combat.Projectiles;
using UnityEngine;

namespace Core.Combat
{
    [Serializable]
    public class Weapon
    {
        public Transform weaponTransform;
        public Vector3 Offset;
        public AbstractProjectile projectilePrefab;
        public bool DestroyHit;
        public float horizontalForce = 5.0f;
        public float verticalForce = 4.0f;
    }
}