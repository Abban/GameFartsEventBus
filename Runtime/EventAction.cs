using System;
using System.Linq;

namespace BBX.Library.EventManagement
{
    public class EventAction<T> : IEventAction<T> where T : IEvent
    {
        private Action<T> _action = delegate { };

        public void AddSubscriber(Action<T> subscriber)
        {
            _action += subscriber;
        }

        public void RemoveSubscriber(Action<T> subscriber)
        {
            _action -= subscriber;
        }

        public bool HasSubscriber(Action<T> subscriber)
        {
            return _action.GetInvocationList().Contains(subscriber);
        }

        public void Fire(T payload)
        {
            _action.Invoke(payload);
        }
    }
}