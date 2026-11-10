//using BehaviorDesigner.Runtime.Tasks;
//using Core.Util;
//using UnityEngine;

//namespace Core.AI
//{
//    public class PlayParticles : EnemyAction
//    {
//        public ParticleSystem effect;

//        public override TaskStatus OnUpdate()
//        {
//            EffectManager.Instance.PlayOneShot(effect, transform.position);
//            return TaskStatus.Success;
//        }
//    }
//}