using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.AI
{
    public class Sequence : TreeNode
    {
        int _currentChildIndex;

        public Sequence()
        {
            Children = new List<TreeNode>();
        }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            for (; _currentChildIndex < Children.Count;)
            {
                var child = Children[_currentChildIndex];
                var state = child.Update(tree, owner);

                switch (state)
                {
                    case TreeNodeState.Success:
                        _currentChildIndex++;
                        continue;
                    case TreeNodeState.Failed:
                        return TreeNodeState.Failed;
                    case TreeNodeState.Running:
                        return TreeNodeState.Running;
                }
            }

            return TreeNodeState.Success;

        }

        protected override void ResetInternal()
        {
            _currentChildIndex = 0;
        }


    }
}
