using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.AI
{
    public class Repeater : TreeNode
    {
        public int RepeatCount = -1;

        int _currentCount;

        public Repeater()
        {
            Children = new List<TreeNode>();
        }

        protected override void ResetInternal()
        {
            _currentCount = 0;
        }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            tree.SetRepeater(this);

            var state = Children[0].Update(tree, owner);

            if (state == TreeNodeState.Success || state == TreeNodeState.Failed)
            {
                _currentCount++;

                if (RepeatCount != -1 && _currentCount >= RepeatCount)
                {
                    return state;
                }
                else
                {
                    Children[0].Reset();
                }
            }

            return state;
        }




    }
}
