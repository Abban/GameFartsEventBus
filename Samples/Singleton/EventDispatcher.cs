using UnityEngine;
using BBX.Library.EventManagement;

namespace EventManagerSingleton
{
    public class EventDispatcher : MonoBehaviour
    {
        public class FireEvent : IEvent
        {
            public Vector2 Direction { get; }

            public FireEvent(Vector2 direction)
            {
                Direction = direction;
            }
        }


        public void Update()
        {
            if (!Input.GetButtonDown("Fire1")) return;
            
            var direction = new Vector2(
                Random.Range(-10f, 10f),
                Random.Range(-10f, 10f)
            );
            
            EventManager.Fire(new FireEvent(direction));
        }
    }
}