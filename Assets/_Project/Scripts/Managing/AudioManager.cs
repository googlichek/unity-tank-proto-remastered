using UnityEngine;

namespace Game.Scripts
{
    public class AudioManager : TickBehaviour
    {
        [SerializeField] private AudioClip _stageClip = null;

        private AudioSource _audioSource;

        public AudioSource AudioSource => _audioSource;

        public AudioClip StageClip => _stageClip;

        public override void Init()
        {
            base.Init();

            _audioSource = GetComponent<AudioSource>();

            priority = TickPriority.High;
        }

        public override void Enable()
        {
            base.Enable();

            PlayClip(_stageClip);
            Loop(true);
        }

        public void PlayClip(AudioClip clip)
        {
            _audioSource.Pause();
            _audioSource.clip = clip;
            _audioSource.Play();
        }

        public void Loop(bool shouldLoop)
        {
            _audioSource.loop = shouldLoop;
        }
    }
}
