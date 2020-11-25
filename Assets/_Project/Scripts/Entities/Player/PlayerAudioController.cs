using UnityEngine;

namespace Game.Scripts
{
    public class PlayerAudioController : TickComponent
    {
        [Header("Sounds")]
        [SerializeField] private AudioClip _weaponChange = null;
        [SerializeField] private AudioClip _primaryShot = null;
        [SerializeField] private AudioClip _secondaryShot = null;

        private AudioSource _audioSource;

        public AudioClip WeaponChange => _weaponChange;
        public AudioClip PrimaryShot => _primaryShot;
        public AudioClip SecondaryShot => _secondaryShot;

        public override void Init()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayClip(AudioClip clip)
        {
            _audioSource.Pause();
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}
