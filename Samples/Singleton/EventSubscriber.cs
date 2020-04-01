using UnityEngine;

namespace EventManagerSingleton
{
    public class EventSubscriber : MonoBehaviour
    {
        private void OnEnable()
        {
            EventManager.Subscribe<EventDispatcher.FireEvent>(OnFire);
        }
        
        
        private void OnDisable()
        {
            EventManager.Unsubscribe<EventDispatcher.FireEvent>(OnFire);
        }


        private void OnFire(EventDispatcher.FireEvent payload)
        {
            Debug.Log( $"Firing in direction {payload.Direction}" );
        }
    }
}