using Core.Character;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.AI
{
    public class SetTrigger : TreeNode
    {
        public string triggerName;

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            owner.GetComponentInChildren<Animator>().SetTrigger(triggerName);

            return TreeNodeState.Success;
        }
    }
}