

using System.Threading.Tasks;
using UnityEngine;

namespace Core.AI
{
    public class ChangeDirection : TreeNode
    {
        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            var scale = owner.transform.localScale;
            scale.x = -scale.x;
            owner.transform.localScale = scale;

            return TreeNodeState.Success;
        }
    }
}