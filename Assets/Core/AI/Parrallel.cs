//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UnityEngine;

//namespace Core.AI
//{
//    public class Parrallele : TreeNode
//    {
//        List<int> _remainingChildren = new List<int>();

//        public Parrallele()
//        {
//            Children = new List<TreeNode>();
//        }

//        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
//        {



//            for (; _currentChildIndex < Children.Count;)
//            {
//                var child = Children[_currentChildIndex];
//                var state = child.Update(tree, owner);

//                switch (state)
//                {
//                    case TreeNodeState.Success:
//                        return TreeNodeState.Success;
//                    case TreeNodeState.Failed:
//                        _currentChildIndex++;
//                        continue;
//                    case TreeNodeState.Running:
//                        return TreeNodeState.Running;
//                }
//            }

//            return TreeNodeState.Success;
//        }

//        protected override void ResetInternal()
//        {
//            _remainingChildren.Clear();
//        }


//    }
//}
