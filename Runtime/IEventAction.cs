using System;

namespace GF.Library.EventManagement
{
    public interface IEventAction<T> where T : IEvent
    {
        void AddSubscriber(Action<T> subscriber);
        void RemoveSubscriber(Action<T> subscriber);
        bool HasSubscriber(Action<T> subscriber);
        void Fire(T payload);
    }
}