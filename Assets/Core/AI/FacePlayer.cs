

using System.Threading.Tasks;
using UnityEngine;

namespace Core.AI
{
    public class FacePlayer : TreeNode
    {
        private float? baseScaleX;

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            if (baseScaleX == null)
            {
                baseScaleX = Mathf.Abs( owner.transform.localScale.x);
            }

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            var scale = owner.transform.localScale;
            scale.x = owner.transform.position.x > player.transform.position.x ? -baseScaleX.Value : baseScaleX.Value;
            owner.transform.localScale = scale;

            return TreeNodeState.Success;
        }
    }
}