using System;
using System.Collections.Generic;

namespace BBX.Library.EventManagement
{
    public class EventBus : IEventBus
    {
        private readonly IDictionary<Type, object> _eventDictionary = new Dictionary<Type, object>();

        public void Subscribe<T>(Action<T> subscriber) where T : IEvent
        {
            if (!_eventDictionary.ContainsKey(typeof(T)))
            {
                _eventDictionary.Add(typeof(T), new EventAction<T>());
            }

            var action = _eventDictionary[typeof(T)] as IEventAction<T>;
            action?.AddSubscriber(subscriber);
        }

        public void Unsubscribe<T>(Action<T> subscriber) where T : IEvent
        {
            if (!_eventDictionary.ContainsKey(typeof(T))) return;
            
            var action = _eventDictionary[typeof(T)] as IEventAction<T>;

            if (action == null || !action.HasSubscriber(subscriber)) return;

            action.RemoveSubscriber(subscriber);
        }

        public void Fire<T>(T payload) where T : IEvent
        {
            var type = payload.GetType();
            
            if (!_eventDictionary.ContainsKey(type)) return;
            
            var action = _eventDictionary[type] as IEventAction<T>;
            
            action?.Fire(payload);
        }
    }
}