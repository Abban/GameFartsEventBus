using System;

namespace BBX.Library.EventManagement
{
    public interface IEventBus
    {
        void Subscribe<T>(Action<T> subscriber) where T : IEvent;
        void Unsubscribe<T>(Action<T> subscriber) where T : IEvent;
        void Fire<T>(T payload) where T : IEvent;
    }
}