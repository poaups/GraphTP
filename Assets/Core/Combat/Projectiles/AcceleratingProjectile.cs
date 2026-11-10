using System.Collections;
using UnityEngine;

namespace Core.Combat.Projectiles
{
    public class AcceleratingProjectile : AbstractProjectile
    {
        public float speed = 5.0f;

        private Vector3 direction;
        private Vector3 velocity;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(6);
            DestroyProjectile();
        }

        public override void SetForce(Vector2 force)
        {
            this.force = force;
            direction = force.normalized;
        }

        void Update()
        {
            velocity += direction * speed * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
        }
    }
}