using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.AI
{
    public class RandomSelector : TreeNode
    {
        int _currentChildIndex;
        List<int> _randomOrder = new List<int>();


        public RandomSelector()
        {
            Children = new List<TreeNode>();
        }

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            if (_randomOrder.Count != Children.Count)
            {
                _randomOrder.Clear();
                for (int i = 0; i < Children.Count; i++)
                {
                    _randomOrder.Add(i);
                }

                Shuffle(_randomOrder);
            }


            for (; _currentChildIndex < Children.Count;)
            {
                int index = _randomOrder[_currentChildIndex];

                var child = Children[index];
                var state = child.Update(tree, owner);

                switch (state)
                {
                    case TreeNodeState.Success:
                        return TreeNodeState.Success;
                    case TreeNodeState.Failed:
                        _currentChildIndex++;
                        continue;
                    case TreeNodeState.Running:
                        return TreeNodeState.Running;
                }
            }

            return TreeNodeState.Success;
        }

        protected override void ResetInternal()
        {
            _currentChildIndex = 0;

            Shuffle(_randomOrder);

        }

        private static System.Random rng = new System.Random();

        void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }
}
