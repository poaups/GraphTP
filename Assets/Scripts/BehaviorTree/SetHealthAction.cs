using System;
using Core.Combat;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetHealthAction", story: "set [Health] of the [agent]", category: "Action", id: "d08865a87f91c4eeb49273b6ee7319ec")]
public partial class SetHealthAction : Action
{
    [SerializeReference] public BlackboardVariable<int> Health;
    [SerializeReference] public BlackboardVariable<GameObject> Agent;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        var destructable = Agent.Value.GetComponent<Destructable>();

        destructable.SetHealth(Health);
        
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

