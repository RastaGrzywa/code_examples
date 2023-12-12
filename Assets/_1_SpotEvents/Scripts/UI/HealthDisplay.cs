using System;
using _1_SpotEvents.Scripts.EventChannels;
using _1_SpotEvents.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _1_SpotEvents.Scripts.UI
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] private PlayerDataSO playerData;
        [SerializeField] private Image healthBar;
        [SerializeField] private TextMeshProUGUI healthText;

        public void UpdatePlayerHealth(int value)
        {
            healthBar.fillAmount = value / (float) playerData.MaxHealth;
            healthText.text = $"HP: {value}";
        }
    }
}