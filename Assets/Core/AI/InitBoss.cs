using Core.Bosses;
using Core.UI;
using UnityEngine;

namespace Core.AI
{
    public class InitBoss : TreeNode
    {
        public string Name { get; set; } = "Default";

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            GuiManager.Instance.ShowBossName(Name);
            return TreeNodeState.Success;
        }

    }
}