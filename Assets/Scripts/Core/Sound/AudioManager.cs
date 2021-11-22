using UnityEngine;

namespace Core.Sound
{
    public class AudioManager : MonoBehaviour
    {
        private AudioSource _sfxSource;
        private AudioSource _musicSource;

        private void Awake()
        {
            _sfxSource = gameObject.AddComponent<AudioSource>();
            _musicSource = gameObject.AddComponent<AudioSource>();
            gameObject.AddComponent<AudioListener>();
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