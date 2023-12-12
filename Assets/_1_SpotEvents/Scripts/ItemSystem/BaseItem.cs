using System;
using _1_SpotEvents.Scripts.EventChannels;
using UnityEngine;

namespace _1_SpotEvents.Scripts.ItemSystem
{
    public abstract class BaseItem<T> : MonoBehaviour
    {
        [SerializeField] private T value;
        [SerializeField] private EventChannel<T> eventChannel;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                eventChannel.Invoke(value);
                Destroy(gameObject);
            }
        }
    }
}