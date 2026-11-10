using System;
using Unity.Behavior;
using UnityEngine;
using Modifier = Unity.Behavior.Modifier;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ForLoop", story: "Repeat [X] times", category: "Flow/",
    id: "315103543cc9d93f92999212a6a7d63a")]
public partial class ForLoopModifier : Modifier
{
    [SerializeReference] public BlackboardVariable<int> X;

    private int m_CompletedRuns;

    protected override Status OnStart()
    {
        m_CompletedRuns = 0;
        if (Child == null)
        {
            return Status.Failure;
        }

        var status = StartNode(Child);
        if (status == Status.Failure || status == Status.Success)
            return Status.Running;

        return Status.Waiting;
    }

    protected override Status OnUpdate()
    {

        Status status = Child.CurrentStatus;
        if (status == Status.Failure || status == Status.Success)
        {
            if (X != 0 && ++m_CompletedRuns >= X)
                return status;

            var newStatus = StartNode(Child);
            if (newStatus == Status.Failure || newStatus == Status.Success)
                return Status.Running;
        }
        return Status.Waiting;
    }

    protected override void OnEnd()
    {
    }
}