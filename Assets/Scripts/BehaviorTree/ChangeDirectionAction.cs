using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ChangeDirectionAction", story: "[Agent] Change direction", category: "Action", id: "3f5b97594136bc4d6928d2442a1b7f35")]
public partial class ChangeDirectionAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        var scale = Agent.Value.transform.localScale;
        scale.x = -scale.x;
        Agent.Value.transform.localScale = scale;

        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

