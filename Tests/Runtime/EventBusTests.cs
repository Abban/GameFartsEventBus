using NUnit.Framework;

namespace GF.Library.EventManagement.Tests
{
    [TestFixture]
    public class EventBusTests
    {
        private class TestEvent : IEvent
        {
        }
        
        [Test]
        public void OnSubscribeThenFire_NotifiesSubscriber()
        {
            var called = false;
            void ActionCallback(TestEvent testEvent)
            {
                called = true;
            }
            
            var eventBus = new EventBus();
            eventBus.Subscribe<TestEvent>(ActionCallback);
            eventBus.Fire(new TestEvent());
            
            Assert.That(called);
        }
        
        [Test]
        public void OnSubscribeMultipleThenFire_NotifiesAllSubscribers()
        {
            var called1 = false;
            var called2 = false;
            
            void ActionCallback1(TestEvent testEvent)
            {
                called1 = true;
            }
            
            void ActionCallback2(TestEvent testEvent)
            {
                called2 = true;
            }
            
            var eventBus = new EventBus();
            eventBus.Subscribe<TestEvent>(ActionCallback1);
            eventBus.Subscribe<TestEvent>(ActionCallback2);
            eventBus.Fire(new TestEvent());
            
            Assert.That(called1);
            Assert.That(called2);
        }
        
        [Test]
        public void OnSubscribeThenFire_SendsCorrectPayload()
        {
            var payload = new TestEvent();
            TestEvent recievedPayload = null;
            
            void ActionCallback(TestEvent testEvent)
            {
                recievedPayload = testEvent;
            }

            var eventBus = new EventBus();
            eventBus.Subscribe<TestEvent>(ActionCallback);
            eventBus.Fire(payload);

            Assert.AreEqual(payload, recievedPayload);
        }
        
        [Test]
        public void OnUnsubscribeThenFire_DoesNotNotifySubscriber()
        {
            var called = false;
            void ActionCallback(TestEvent testEvent)
            {
                called = true;
            }
            
            var eventBus = new EventBus();
            eventBus.Subscribe<TestEvent>(ActionCallback);
            eventBus.Unsubscribe<TestEvent>(ActionCallback);
            eventBus.Fire(new TestEvent());
            
            Assert.That(!called);
        }
        
    }
}