using Core.Character;
using Core.Combat;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.AI
{
    public class Jump : TreeNode
    {
        public float horizontalForce = 5.0f;
        public float jumpForce = 10.0f;

        public float buildupTime;
        public float jumpTime;

        public string animationTriggerName;
        public bool shakeCameraOnLanding;

        private bool hasLanded;

        private Tween buildupTween;
        private Tween jumpTween;

        bool _initialized;


        protected override void ResetInternal()
        {
            hasLanded = false;
            _initialized = false;
        }

        private void StartJump(GameObject owner)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player"); 

            var direction = player.transform.position.x < owner.transform.position.x ? -1 : 1;
            owner.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalForce * direction, jumpForce), ForceMode2D.Impulse);

            jumpTween = DOVirtual.DelayedCall(jumpTime, () =>
            {
                hasLanded = true;
                if (shakeCameraOnLanding)
                    CameraController.Instance.ShakeCamera(0.5f);
            }, false);
        }


        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            if (_initialized == false)
            {
                owner.GetComponent<Destructable>().Invincible = true;

                _initialized = true;
                buildupTween = DOVirtual.DelayedCall(buildupTime, () => StartJump(owner), false);
                owner.GetComponentInChildren<Animator>().SetTrigger(animationTriggerName);
            }

            if (hasLanded)
            {
                buildupTween?.Kill();
                jumpTween?.Kill();
                hasLanded = false;
                owner.GetComponent<Destructable>().Invincible = false;


                return TreeNodeState.Success;
            }


            return TreeNodeState.Running;
        }
    }
}