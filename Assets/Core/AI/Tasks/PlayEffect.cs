//using BehaviorDesigner.Runtime.Tasks;
//using Core.Util;
//using UnityEngine;

//namespace Core.AI
//{
//    public class PlaySpriteEffect : EnemyAction
//    {
//        public SpriteRenderer effect;
//        public Vector3 offset;
//        public bool flipX;
        
//        public override TaskStatus OnUpdate()
//        {
//            EffectManager.Instance.PlaySpriteOneShot(effect, transform.position + offset, flipX);
//            return TaskStatus.Success;
//        }
//    }
//}