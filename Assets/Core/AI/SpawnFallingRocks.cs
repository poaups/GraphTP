using Core.Combat.Projectiles;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.AI
{
    public class SpawnFallingRocks : TreeNode
    {
        public Collider2D spawnAreaCollider;
        public AbstractProjectile rockPrefab;
        public int spawnCount = 4;
        public float spawnInterval = 0.3f;

        public override TreeNodeState Update(BehaviorTree tree, GameObject owner)
        {
            var sequence = DOTween.Sequence();
            for (int i = 0; i < spawnCount; i++)
            {
                sequence.AppendCallback(SpawnRock);
                sequence.AppendInterval(spawnInterval);
            }

            return  TreeNodeState.Success;
        }


        private void SpawnRock()
        {
            var randomX = Random.Range(spawnAreaCollider.bounds.min.x, spawnAreaCollider.bounds.max.x);
            var rock = Object.Instantiate(rockPrefab, new Vector3(randomX, spawnAreaCollider.bounds.min.y),
                Quaternion.identity);
            rock.SetForce(Vector2.zero);
        }
    }
}