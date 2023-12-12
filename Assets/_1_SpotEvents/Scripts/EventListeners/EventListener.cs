using _1_SpotEvents.Scripts.EventChannels;
using UnityEngine;
using UnityEngine.Events;

namespace _1_SpotEvents.Scripts.EventListeners
{
    public abstract class EventListener<T> : MonoBehaviour
    {
        [SerializeField] private EventChannel<T> eventChannel;
        [SerializeField] private UnityEvent<T> unityEvent;

        private void Awake()
        {
            eventChannel.Register(this);
        }

        private void OnDestroy()
        {
            eventChannel.Deregister(this);
        }

        public void Raise(T value)
        {
            unityEvent?.Invoke(value);   
        }
    }
}