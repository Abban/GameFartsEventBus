# Game Farts Unity Event Bus 

Vroom.

This is a small library to manage events in Unity.

## Installation
You can install this in Unity as a Package by going to `Window > Package Manager` And then hitting the `+` and selecting `Add Package from git URL`. 

## Usage

To use it you can either instantiate a new `EventBus` in your container classes for injection or create one as a humble object in a singleton MonoBehaviour. If you want to use a singleton you can check out the installable example through the package manager.

### Event Payloads

All events have a payload that has to implement the `IEvent` interface.

```c#
public class FireEvent : IEvent
{
    public Vector2 Direction { get; }

    public FireEvent(Vector2 direction)
    {
        Direction = direction;
    }
}
```

You can subscribe and unsubscribe to an event in your MonoBehaviours like this:

```c#
private void OnEnable()
{
    _eventBus.Subscribe<FireEvent>(OnFire);
}

private void OnDisable()
{
    _eventBus.Unsubscribe<FireEvent>(OnFire);
}

private void OnFire(FireEvent payload)
{
    Debug.Log( $"Firing in direction {payload.Direction}" );
}
```

And you can fire events like this:

```c#
var direction = new Vector2(
    Random.Range(-10f, 10f),
    Random.Range(-10f, 10f)
);

_eventBus.Fire(new FireEvent(direction));
```