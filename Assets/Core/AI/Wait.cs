using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.AI
{
    class Wait : TreeNode
    {
        public float Timer { get; set; }

        float _currentTime;

        protected override void ResetInternal()
        {
            _currentTime = 0;
        }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime < Timer)
                return TreeNodeState.Running;

            return TreeNodeState.Success;
        }


    }
}
