using System;
using Core.Combat;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Core;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "idk", story: "IDK", category: "Action", id: "a51f44de0f95d94c17c2db85431aa5cc")]
public partial class IDK : Action
{
	[SerializeReference] public BlackboardVariable<bool> End;
	[SerializeReference] public BlackboardVariable<GameObject> Agent;

	protected override Status OnStart()
	{
		return Status.Running;
	}

	protected override Status OnUpdate()
	{
		GameManager.Instance.NewPart();
		return Status.Success;
	}

	protected override void OnEnd()
	{
	}
}

