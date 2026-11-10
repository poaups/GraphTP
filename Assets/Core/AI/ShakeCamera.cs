using Core.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.AI
{
    class ShakeCamera : TreeNode
    {
        public float Intensity { get; set; } = 0.5f;

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            CameraController.Instance.ShakeCamera(Intensity);
            return TreeNodeState.Success;
        }
    }
}
