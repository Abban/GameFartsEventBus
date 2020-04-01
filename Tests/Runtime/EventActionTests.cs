using NUnit.Framework;

namespace BBX.Library.EventManagement.Tests
{
    [TestFixture]
    public class EventActionTests
    {
        private class TestEvent : IEvent
        {
        }

        [Test]
        public void OnAddSubscriber_AddsSubscriber()
        {
            void ActionCallback(TestEvent testEvent)
            {
            }

            var eventAction = new EventAction<TestEvent>();
            eventAction.AddSubscriber(ActionCallback);

            Assert.That(eventAction.HasSubscriber(ActionCallback));
        }

        [Test]
        public void OnRemoveSubscriber_RemovesSubscriber()
        {
            void ActionCallback(TestEvent testEvent)
            {
            }

            var eventAction = new EventAction<TestEvent>();
            eventAction.AddSubscriber(ActionCallback);
            eventAction.RemoveSubscriber(ActionCallback);

            Assert.That(!eventAction.HasSubscriber(ActionCallback));
        }


        [Test]
        public void OnFire_NotifiesSubscriber()
        {
            var called = false;
            
            void ActionCallback(TestEvent testEvent)
            {
                called = true;
            }

            var eventAction = new EventAction<TestEvent>();
            eventAction.AddSubscriber(ActionCallback);
            eventAction.Fire(new TestEvent());

            Assert.That(called);
        }
        
        [Test]
        public void OnFire_SendsCorrectPayload()
        {
            var payload = new TestEvent();
            TestEvent recievedPayload = null;
            
            void ActionCallback(TestEvent testEvent)
            {
                recievedPayload = testEvent;
            }

            var eventAction = new EventAction<TestEvent>();
            eventAction.AddSubscriber(ActionCallback);
            eventAction.Fire(payload);

            Assert.AreEqual(payload, recievedPayload);
        }
        
        
        [Test]
        public void OnFireWithMultiple_NotifiesAllSubscribers()
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

            var eventAction = new EventAction<TestEvent>();
            eventAction.AddSubscriber(ActionCallback1);
            eventAction.AddSubscriber(ActionCallback2);
            eventAction.Fire(new TestEvent());

            Assert.That(called1);
            Assert.That(called2);
        }
    }
}