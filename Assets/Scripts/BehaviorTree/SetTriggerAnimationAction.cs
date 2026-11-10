using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetTriggerAnimation", story: "Set [TriggerName] animation on [agent]", category: "Action", id: "d1fc1ec4ede2d981d6c97e8b27d970aa")]
public partial class SetTriggerAnimationAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<string> TriggerName;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Agent.Value.GetComponentInChildren<Animator>().SetTrigger(TriggerName);
        
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

