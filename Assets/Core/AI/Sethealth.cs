using Core.Combat;
using UnityEngine;

namespace Core.AI
{
    public class SetHealth : TreeNode
    {
        public int Health = 30;

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            var destructable = owner.GetComponent<Destructable>();

            destructable.SetHealth(Health);

            return TreeNodeState.Success;
        }

        protected override void ResetInternal()
        {
        }
    }
}