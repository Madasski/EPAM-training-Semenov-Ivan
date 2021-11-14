using UnityEngine;

namespace Core.Services
{
    public class AudioManager : MonoBehaviour, IService
    {
        private AudioSource _sfxSource;

        private void Awake()
        {
            ServiceLocator.Instance.Register(this);
            _sfxSource = gameObject.AddComponent<AudioSource>();
        }

        public void PlaySound(AudioClip audioClip)
        {
            _sfxSource.PlayOneShot(audioClip);
        }
    }
}