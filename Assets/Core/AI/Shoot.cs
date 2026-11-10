using System.Collections.Generic;
using Core.Character;
using Core.Combat;
using UnityEngine;

namespace Core.AI
{
    public class Shoot : TreeNode
    {
        public List<Weapon> weapons = new List<Weapon>();
        public bool shakeCamera;

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            foreach (var weapon in weapons)
            {
                var projectile = Object.Instantiate(weapon.projectilePrefab, weapon.weaponTransform.position + weapon.Offset,
                    Quaternion.identity);
                projectile.Shooter = owner;

                var force = new Vector2(weapon.horizontalForce * owner.transform.localScale.x, weapon.verticalForce);
                projectile.SetForce(force);

                if (shakeCamera)
                    CameraController.Instance.ShakeCamera(0.5f);
            }

            return TreeNodeState.Success;
        }
    }
}