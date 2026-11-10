using System;
using System.Collections.Generic;
using UnityEngine;
namespace Core.AI
{
    public class BehaviorTree : MonoBehaviour
    {
        public TreeNode Root { get; set; }

        TreeNode _currentNode;
        Dictionary<string, float> _blackboard;

        private void Awake()
        {
            _blackboard = new Dictionary<string, float>();
        }

        private void Update()
        {
            if ( _currentNode != null)
            {
                if (_currentNode.Update(this, gameObject) != TreeNodeState.Running)
                {
                    _currentNode = null;
                }
            }
            else
            {
                Root.Update(this, gameObject);
            }
        }

        public void WriteBlackboard(string name , float value)
        {
            _blackboard[name] = value;
        }

        public float ReadBlackboard(string name)
        {
            if (_blackboard.TryGetValue(name, out float value))
                return value;
            return 0;
        }


        internal void SetRepeater(Repeater repeater)
        {
            _currentNode = repeater; 
        }
    }

}
