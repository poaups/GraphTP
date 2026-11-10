using Core.Combat;
using UnityEngine;

namespace Core.AI
{
    public class WaitOrhealthUnder : TreeNode
    {
        public int HealthTreshold = 30;
        public float Timer { get; set; }
        float _currentTime;


        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            var destructable = owner.GetComponent<Destructable>();

            if (destructable.CurrentHealth <= HealthTreshold)
                return TreeNodeState.Failed;

            _currentTime += Time.deltaTime;

            if (_currentTime < Timer)
                return TreeNodeState.Running;

            return TreeNodeState.Success;

        }


        protected override void ResetInternal()
        {
            _currentTime = 0;
        }


    }
}