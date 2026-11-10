using System;
using Core.Character;
using Core.Combat.Projectiles;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ShootAction", story: "Create a [Projectile] at [weaponTransform]", category: "Action", id: "81ee7c3b13ce176fbc4364c26bd00ac5")]
public partial class ShootAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> weaponTransform;
    [SerializeReference] public BlackboardVariable<Vector3> Offset;
    [SerializeReference] public BlackboardVariable<GameObject> Projectile;
    [SerializeReference] public BlackboardVariable<float> horizontalForce;
    [SerializeReference] public BlackboardVariable<float> verticalForce;
    [SerializeReference] public BlackboardVariable<bool> shakeCamera;
    [SerializeReference] public BlackboardVariable<GameObject> Agent;

    

    protected override Status OnStart()
    {
        var projectile = GameObject.Instantiate(Projectile.Value, weaponTransform.Value.position + Offset,
            Quaternion.identity).GetComponent<AbstractProjectile>();
        projectile.Shooter = Agent.Value;

        var force = new Vector2(horizontalForce * Agent.Value.transform.localScale.x, verticalForce);
        projectile.SetForce(force);

        if (shakeCamera)
            CameraController.Instance.ShakeCamera(0.5f);
        
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

