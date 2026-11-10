//using BehaviorDesigner.Runtime.Tasks;
//using UnityEngine;

//namespace Core.AI
//{
//    public class CheckPlayerInRange : EnemyConditional
//    {
//        public float range;
        
//        public override TaskStatus OnUpdate()
//        {
//            var distanceX = Mathf.Abs(player.transform.position.x - transform.position.x);
//            return distanceX < range ? TaskStatus.Success : TaskStatus.Failure;
//        }
//    }
//}