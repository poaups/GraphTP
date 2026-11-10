using Unity.Behavior;
using UnityEngine;
using Action = System.Action;

namespace Core.Combat
{
    public class Destructable : Hittable
    {
        public int health = 10;

        public int CurrentHealth { get; set; }
        public bool Invincible { get; set; }

        public event Action OnDestroyed;

        private BehaviorGraphAgent _agent;

        protected override void Awake()
        {
            base.Awake();
            CurrentHealth = health;
            Invincible = false;

            _agent = GetComponent<BehaviorGraphAgent>();
        }

        public override void OnAttackHit(Vector2 position, Vector2 force, int damage)
        {
            if (CurrentHealth <= 0 || Invincible)
                return;

            DealDamage(damage);

            base.OnAttackHit(position, force, damage); // Order of this call is important
        }

        public void DealDamage(int damage)
        {
            CurrentHealth -= damage;
            
            _agent?.BlackboardReference.SetVariableValue("Health", CurrentHealth);
            
            if (CurrentHealth <= 0)
            {
                OnDestroyed?.Invoke();
            }
        }

        public void Revive()
        {
        }

        internal void SetHealth(int health)
        {
            CurrentHealth = health;

            _agent?.BlackboardReference.SetVariableValue("Health", CurrentHealth);
        }
    }
}