using System;
using Core.Combat;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SpawnAndWaitDeadAction",
    story:
    "spawn a [Prefab] gameobject at [Parent] position and wait for the player to destroy it, disable the [Collider] of the agent",
    category: "Action", id: "6684d193ae74f21d81bfa7750350eef8")]
public partial class SpawnAndWaitDeadAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Prefab;
    [SerializeReference] public BlackboardVariable<Transform> ParentPosition;
    [SerializeReference] public BlackboardVariable<GameObject> Collider;

    private Destructable _instance;

    protected override Status OnStart()
    {
        GameObject go = GameObject.Instantiate(Prefab.Value, ParentPosition.Value);
        _instance = go.GetComponent<Destructable>();
        _instance.transform.localPosition = Vector3.zero;
        Agent.Value.GetComponent<Destructable>().Invincible = true;
        Collider.Value.SetActive(false);

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (_instance.CurrentHealth > 0) return Status.Running;

        Agent.Value.GetComponent<Destructable>().Invincible = false;
        Collider.Value.SetActive(true);

        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}