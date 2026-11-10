

using Core.Combat;
using UnityEngine;

namespace Core.AI
{
    public class IsHealthUnder : TreeNode
    {
        public int HealthTreshold = 30;

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            var destructable = owner.GetComponent<Destructable>();

            return destructable.CurrentHealth <= HealthTreshold ?  TreeNodeState.Success :  TreeNodeState.Failed;
        }


    }
}