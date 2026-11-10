

using Core.Combat;
using UnityEngine;

namespace Core.AI
{
    public class CheckBlackboard : TreeNode
    {
        public int Value ;
        public string Name;

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            if (tree.ReadBlackboard(Name) == Value)
                return TreeNodeState.Success;
            else return TreeNodeState.Failed;
        }


    }
}