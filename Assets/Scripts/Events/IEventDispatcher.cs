using System;

namespace Events
{
    public interface IEventDispatcher
    {
        void Subscribe<T>(Action<T> callback) where T : BaseEvent;
        void Unsubscribe<T>(Action<T> callback) where T : BaseEvent;
        void Dispatch<T>(T arg = default) where T : BaseEvent;
    }
}