using System;
using Core.AI;
using Core.Character;
using Core.Combat;
using DG.Tweening;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Jump", story: "Makes the [Agent] jump", category: "Action",
    id: "24c4100af70489650d8c46872f87cbe1")]
public partial class JumpAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<float> buildupTime;
    [SerializeReference] public BlackboardVariable<string> animationTriggerName;
    [SerializeReference] public BlackboardVariable<float> horizontalForce;
    [SerializeReference] public BlackboardVariable<float> jumpForce;
    [SerializeReference] public BlackboardVariable<float> jumpTime;
    [SerializeReference] public BlackboardVariable<bool> shakeCameraOnLanding;

    private Tween buildupTween;
    private Tween jumpTween;
    private bool hasLanded;

    protected override Status OnStart()
    {
        Agent.Value.GetComponent<Destructable>().Invincible = true;

        buildupTween = DOVirtual.DelayedCall(buildupTime, () => StartJump(Agent.Value), false);
        Agent.Value.GetComponentInChildren<Animator>().SetTrigger(animationTriggerName);

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (hasLanded)
        {
            buildupTween?.Kill();
            jumpTween?.Kill();
            hasLanded = false;
            Agent.Value.GetComponent<Destructable>().Invincible = false;

            return Status.Success;
        }


        return Status.Running;
    }

    private void StartJump(GameObject owner)
    {
        var direction = Player.Value.transform.position.x < owner.transform.position.x ? -1 : 1;
        owner.GetComponent<Rigidbody2D>()
            .AddForce(new Vector2(horizontalForce * direction, jumpForce), ForceMode2D.Impulse);

        jumpTween = DOVirtual.DelayedCall(jumpTime, () =>
        {
            hasLanded = true;
            if (shakeCameraOnLanding)
                CameraController.Instance.ShakeCamera(0.5f);
        }, false);
    }

    protected override void OnEnd()
    {
    }
}