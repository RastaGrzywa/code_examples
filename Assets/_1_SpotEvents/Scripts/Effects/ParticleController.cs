using UnityEngine;

namespace _1_SpotEvents.Scripts.Effects
{
    public class ParticleController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem healParticleSystem;
        [SerializeField] private ParticleSystem damageParticleSystem;
        
        public void OnPlayerHealthUpdate(int value)
        {
            if (value > 0)
            {
                healParticleSystem.Play();
            }

            if (value < 0)
            {
                damageParticleSystem.Play();
            }
        }
    }
}