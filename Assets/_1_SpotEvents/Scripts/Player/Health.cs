using System;
using _1_SpotEvents.Scripts.EventChannels;
using UnityEngine;

namespace _1_SpotEvents.Scripts.Player
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private IntEventChannel currentHealthChannel;
        [SerializeField] private PlayerDataSO playerData;
        private int _currentHealth;

        private void Start()
        {
            ChangePlayerHealth(playerData.MaxHealth);
        }

        public void ChangePlayerHealth(int value)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + value, 0, playerData.MaxHealth);
            currentHealthChannel.Invoke(_currentHealth);
        }
    }
}