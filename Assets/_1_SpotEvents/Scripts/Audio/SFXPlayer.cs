using System;
using UnityEngine;

namespace _1_SpotEvents.Scripts.Audio
{
    public class SFXPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip healSound;
        [SerializeField] private AudioClip damageSound;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayerChangeHealth(int value)
        {
            if (value > 0)
            {
                _audioSource.clip = healSound;
            }

            if (value < 0)
            {
                _audioSource.clip = damageSound;
            }
            
            _audioSource.Play();
        }
    }
}