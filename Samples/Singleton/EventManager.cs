using System;
using UnityEngine;
using BBX.Library.EventManagement;

namespace EventManagerSingleton
{
    public class EventManager : MonoBehaviour
    {
        private IEventBus _eventBus;

        private static EventManager _eventManager;

        public static EventManager Instance
        {
            get
            {
                if (_eventManager) return _eventManager;

                _eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!_eventManager || _eventManager == null)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    _eventManager.Init();
                }

                return _eventManager;
            }
        }

        private void Init()
        {
            if (_eventBus == null)
            {
                _eventBus = new EventBus();
            }
        }

        public static void Subscribe<T>(Action<T> subscriber) where T : IEvent
        {
            Instance._eventBus.Subscribe<T>(subscriber);
        }

        public static void Unsubscribe<T>(Action<T> subscriber) where T : IEvent
        {
            Instance._eventBus.Unsubscribe<T>(subscriber);
        }

        public static void Fire<T>(T payload) where T : IEvent
        {
            Instance._eventBus.Fire(payload);
        }
    }
}