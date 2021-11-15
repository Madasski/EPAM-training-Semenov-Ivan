using UnityEngine;

namespace Core.Services
{
    public class AudioManager : MonoBehaviour, IService
    {
        private AudioSource _sfxSource;
        private AudioSource _musicSource;

        private void Awake()
        {
            ServiceLocator.Instance.Register(this);
            _sfxSource = gameObject.AddComponent<AudioSource>();
            _musicSource = gameObject.AddComponent<AudioSource>();
        }

        public void PlaySound(AudioClip audioClip)
        {
            _sfxSource.PlayOneShot(audioClip);
        }

        public void PlayMusic(AudioClip musicClip)
        {
            _musicSource.loop = true;
            _musicSource.clip = musicClip;
            _musicSource.Play();
        }
    }
}