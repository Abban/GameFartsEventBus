using System;
using UnityEngine;

namespace GF.Library.EventManagement
{
    [CreateAssetMenu(fileName = "EventBus", menuName = "GF/Event Bus")]
    public class EventBusScriptableObject : ScriptableObject, IEventBus
    {
        private IEventBus _eventBus;

        private IEventBus EventBus
        {
            get
            {
                if (_eventBus == null)
                {
                    _eventBus = new EventBus();
                }

                return _eventBus;
            }
        }
        
        
        public void Subscribe<T>(Action<T> subscriber) where T : IEvent
        {
            EventBus.Subscribe(subscriber);
        }

        
        public void Unsubscribe<T>(Action<T> subscriber) where T : IEvent
        {
            EventBus.Unsubscribe(subscriber);
        }

        
        public void Fire<T>(T payload) where T : IEvent
        {
            EventBus.Fire(payload);
        }
    }
}