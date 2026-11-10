using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.AI
{
    class Log : TreeNode
    {
        public string Text { get; set; }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            Debug.Log(Text);

            return TreeNodeState.Success;
        }
    }
}
