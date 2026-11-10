using Core.Combat;
using UnityEngine;

namespace Core.AI
{
    public class SpawnAndWaitDead : TreeNode
    {
        public GameObject Prefab;
        public Transform Transform;
        public GameObject DamageCollider;



        bool _initialized;
        Destructable _instance;

 
        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {

            if (_initialized == false )
            {
                _initialized = true;
                _instance = Object.Instantiate(Prefab, Transform).GetComponent<Destructable>();
                _instance.transform.localPosition = Vector3.zero;
                owner.GetComponent<Destructable>().Invincible = true;
                DamageCollider.SetActive(false);
            }

            if (_instance.CurrentHealth > 0) return  TreeNodeState.Running;

            owner.GetComponent<Destructable>().Invincible = false;
            DamageCollider.SetActive(true);
            return TreeNodeState.Success;

        }

        protected override void ResetInternal()
        {
            _initialized = false;
            _instance = null;
        }

    }
}