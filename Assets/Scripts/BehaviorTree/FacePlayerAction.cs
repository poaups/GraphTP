using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FacePlayer", story: "[Agent] face [player]", category: "Action", id: "e15c075ec4ecd869d08998c48473b376")]
public partial class FacePlayerAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<float> BaseScale;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        var scale = Agent.Value.transform.localScale;
        scale.x = Agent.Value.transform.position.x > Player.Value.transform.position.x ? -BaseScale : BaseScale;
        Agent.Value.transform.localScale = scale;
        
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

