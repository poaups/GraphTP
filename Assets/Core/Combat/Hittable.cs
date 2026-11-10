using System;
using System.Collections;
using Core.Character;
using Core.Util;
using DG.Tweening;
using UnityEngine;

namespace Core.Combat
{
    public class Hittable : MonoBehaviour
    {
        public enum HitType
        {
            None,
            Inflate,
            Push,
            Color
        }

        private static readonly Color DeadColor = new Color(0.4f, 0.4f, 0.4f);
        private static readonly Color HitColor = new Color(0.2f, 0.0f, 0.0f);
        private static readonly AnimationCurve HitWobble = new AnimationCurve(
            new Keyframe(0f, 0f, 11.01978f, 30.76278f),
            new Keyframe(0.08054394f, 1f, 0f, 0f),
            new Keyframe(0.3153235f, -0.75f, 0f, 0f),
            new Keyframe(0.5614113f, 0.5f, 0f, 0f),
            new Keyframe(0.75f, -0.25f, 0f, 0f),
            new Keyframe(0.9086903f, 0.1361611f, 0f, 0f),
            new Keyframe(1f, 0f, -4.159244f, -1.351373f));

        public HitType hitType = HitType.None;
        public bool disableHitEffect = false;
        public Transform spriteParent;
        public ParticleSystem customHitEffect;
        public AudioClip customHitSound;
        public bool hideWhenDead = false;
        public Material hitMaterial;

        private SpriteRenderer sprite;
        private float baseScale;
        protected Color defaultColor = Color.white;
        private Material defaultMaterial;
        private Tween hitTween;

        public event Action<Vector2, Vector2> OnHit;

        // Start is called before the first frame update
        protected virtual void Awake()
        {
            // Find all child sprite renderers
            Transform spriteParentTransform = spriteParent != null ? spriteParent : transform;
            sprite = spriteParentTransform.GetComponentInChildren<SpriteRenderer>();

            baseScale = transform.localScale.y;
            defaultMaterial = sprite.material;
        }

        public virtual void OnAttackHit(Vector2 position, Vector2 force, int damage)
        {
            // Hurt/Damage
            OnHit?.Invoke(position, force);

            if (hitType == HitType.Inflate)
            {
                hitTween?.Kill();
                transform.localScale = new Vector3(transform.localScale.x, baseScale, baseScale);
                hitTween = transform.DOScale(
                        new Vector3(transform.localScale.x * 1.01f, baseScale + 0.05f, baseScale), 0.5f)
                    .SetEase(HitWobble);
            }
            else if (hitType == HitType.Push)
            {
                // Push object quickly by a small amount and return to its original position
                float hitAmount = 0.05f;
                hitTween?.Kill();
                hitTween = transform.DOMove(
                        transform.position + new Vector3(UnityEngine.Random.Range(-hitAmount, hitAmount),
                            UnityEngine.Random.Range(-hitAmount, hitAmount), 0), 0.5f)
                    .SetEase(HitWobble);
            }
            else if (hitType == HitType.Color)
            {
                // Impact color flash
                sprite.material = hitMaterial;
                StartCoroutine(ResetMaterial(0.1f));
            }

            // Impact particle effect
            if (!disableHitEffect)
            {
                if (customHitEffect != null)
                    EffectManager.Instance.PlayOneShot(customHitEffect, position);

                CameraController.Instance.ShakeCamera(1, 1);
            }

            if (customHitSound != null)
                SoundManager.Instance.PlaySoundAtLocation(customHitSound, transform.position);
        }

        protected virtual void OnDestroy()
        {
            hitTween?.Kill();
        }

        private IEnumerator ResetMaterial(float delay)
        {
            yield return new WaitForSeconds(delay);
            sprite.material = defaultMaterial;
        }
    }
}
