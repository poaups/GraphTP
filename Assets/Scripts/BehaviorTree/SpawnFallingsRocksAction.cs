using System;
using Core.Combat.Projectiles;
using DG.Tweening;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Random = UnityEngine.Random;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Spawn fallings rocks", story: "spawn falling [rocks] in [spawnArea]", category: "Action", id: "fb78a8428315eab6f0e972e25858d9c4")]
public partial class SpawnFallingsRocksAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Rocks;
    [SerializeReference] public BlackboardVariable<BoxCollider2D> SpawnArea;
    [SerializeReference] public BlackboardVariable<int> spawnCount;
    [SerializeReference] public BlackboardVariable<float> spawnInterval;
    

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        var sequence = DOTween.Sequence();
        for (int i = 0; i < spawnCount; i++)
        {
            sequence.AppendCallback(SpawnRock);
            sequence.AppendInterval(spawnInterval);
        }

        return  Status.Success;
    }

    protected override void OnEnd()
    {
    }
    
    private void SpawnRock()
    {
        var randomX = Random.Range(SpawnArea.Value.bounds.min.x, SpawnArea.Value.bounds.max.x);
        var rock = GameObject.Instantiate(Rocks.Value, new Vector3(randomX, SpawnArea.Value.bounds.min.y),
            Quaternion.identity).GetComponent<AbstractProjectile>();
        
        rock.SetForce(Vector2.zero);
    }
}

