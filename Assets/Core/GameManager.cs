using System.Collections;
using TMPro;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public AudioSource source;
        public AudioSource sourceJump;
        public AudioSource Shocwave;
        [SerializeField] private Animator animator;
        [SerializeField] private TextMeshProUGUI txt;

        int phase = 0;
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        public void JumpSong()
        {
            sourceJump.Play();

		}
		public void ShockWave()
		{
			sourceJump.Play();

		}
		public void NewPart()
        {
			txt.text = "Phase : " + phase.ToString(); 
			animator.Play("Down");
            source.Play();
			phase++;
        }
        public void FreezeTime(float duration)
        {
            Time.timeScale = 0.1f;
            StartCoroutine(UnfreezeTime(duration));
        }
        
        private IEnumerator UnfreezeTime(float duration)
        {
            yield return new WaitForSeconds(duration);
            Time.timeScale = 1.0f;
        }
    }
}